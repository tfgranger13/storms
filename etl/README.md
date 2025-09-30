This pipeline is designed to parse HURDAT2 data from a csv file, identify storms that have had landfall in Florida since 1900, and write the output to another csv file.

To run this pipeline (shown commands are for Windows):
1. Create a virtual environment
```
python -m venv storms_venv
```
2. Activate the virtual environment
```
storms_venv\Scripts\activate.bat
```
3. Install the dependency requirements
```
pip install -r requirements.txt
```
4. Run the pipeline
```
python etl_pipeline.py
```
5. Deactivate the virtual environment after the pipeline has finished running
```
deactivate
```