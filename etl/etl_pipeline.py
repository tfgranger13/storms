# This pipeline is designed to parse the HURDAT2 dataset to identify all storms since 1900 that have had landfall in Florida.
# It will write the results to a CSV file including the ID, Name, Date of Landfall, and Maximum Wind Speed.
# This output will then be read to populate the Blazor app database to display in the UI.
# It will also be available to download from the UI.

import pandas as pd
import csv
from pandas import api
import requests
import time
from requests_cache import CachedSession
from datetime import timedelta


def etl_pipeline():
    # Using requests-cache to cache API responses to avoid hitting rate limits during testing
    session = CachedSession(
                'rev_geo_cache',
                expire_after=timedelta(days=1),  # Responses expire after 1 day
                cache_control=True  # Respect Cache-Control headers if present
            )

    with open('../storms/wwwroot/Data/HURDAT2_2025-09-26.csv', mode='r') as file:
        csv_reader = csv.reader(file)
        data_storms = []

        # Variables to hold storm data to be saved while parsing entries
        id = ""
        name = ""
        landfall_date = None
        max_wind_speed = 0

        remaining_entries = 0 # Counter for identifying header rows

        for row in csv_reader:
            if remaining_entries == 0 and row[0].strip(): # Process as a storm header row
                id = row[0].strip()
                name = row[1].strip()
                remaining_entries = int(row[2].strip())
            elif row[0].strip(): # Process as storm entry row
                temp_landfall_date = pd.to_datetime(row[0].strip()[:8], format='%Y%m%d').date()
                # temp_identifier = row[2].strip() # using reverse geocoding instead of landfall identifier
                temp_latitude = float(row[4].strip()[:-1])
                temp_longitude = float(row[5].strip()[:-1])
                temp_max_wind_speed = int(row[6].strip())

                if temp_max_wind_speed > max_wind_speed:
                    max_wind_speed = temp_max_wind_speed

                # Use FL lat/long, date to determine if reverse geocoding is needed
                if (
                    24.27 <= temp_latitude <= 31.0
                    and 80.02 <= temp_longitude <= 87.38
                    and temp_landfall_date >= pd.to_datetime("1900-01-01").date()
                ):
                    resp = rev_geo_api(session, temp_latitude, temp_longitude)
                    print("API Response:", resp)
                    time.sleep(1) # To avoid hitting API rate limits
                    if resp is not None and "error" in resp:
                        print(f"Error: {resp.get("error")}")
                    elif resp is not None and "address" in resp and resp.get("address").get("state") == "Florida":
                        landfall_date = temp_landfall_date
                    
                    # Alternate logic if using Landfall identifier from HURDAT2 data
                    # if temp_identifier == "L": 
                    #     landfall_date = temp_landfall_date

                remaining_entries -= 1

                if remaining_entries == 0 and landfall_date is not None:
                    data_storms.append({
                        'Id': id,
                        'Name': name,
                        'LandfallDate': landfall_date,
                        'MaxWindSpeed': max_wind_speed
                    })
                
                if remaining_entries == 0:
                    id = ""
                    name = ""
                    landfall_date = None
                    max_wind_speed = 0

        output_filename = '../storms/wwwroot/Data/py_parsed_rev_geo.csv'
        with open(output_filename, 'w', newline='') as csvfile:
            fieldnames = ['Id', 'Name', 'LandfallDate', 'MaxWindSpeed']
            writer = csv.DictWriter(csvfile, fieldnames=fieldnames)

            writer.writeheader()
            for storm in data_storms:
                writer.writerow(storm)
        
        print(f"Output file written to {output_filename}")


def rev_geo_api(session, lat, long):
    headers = {
        'User-Agent': 'FloridaStormLandfall/1.0 (contact: tfgranger13@gmail.com)'
    }
    # Documentation for this API call found at: https://nominatim.org/release-docs/develop/api/Reverse/
    url = f"https://nominatim.openstreetmap.org/reverse?format=jsonv2&lat={lat}&lon=-{long}&zoom=5&addressdetails=1"
    try:
        response = session.get(url, headers=headers)
        if response.status_code == 200:
            return response.json()
        else:
            print(f"API request failed with status code {response.status_code}")
            return None
    except requests.exceptions.RequestException as e:
        print(f"API request error: {e}")
        return None


if __name__ == "__main__":
    etl_pipeline()