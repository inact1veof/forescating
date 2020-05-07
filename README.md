# Program for short-term forescating time series
I have just started learning the c# language, so this code can have many errors and flaws. This repository was created to represent my results. This program will be further developed in the future.
This repository is developing a program for short term forecasting of time series values.
The program is based on Influx and Grafana. The program has 5 built-in algorithms, including 2 naive ones. The algorithms are described below.

# Program architecture
The main idea of the program, writing to the source data array and a time point for each value. Files are imported from excel by selecting a file from the program window.
At the moment, there is no provision for checking the input file, so the correctness of the data is on your conscience.

The format of the input data:
DateTime            | Value
01.01.2015 00:00:00 | 0.5
01.01.2015 01:00:00 | 0.75
..........................

The data is imported into the program and placed in an array. Next, all logical algorithms use the source array to predict values.
Data is written to new arrays and subsequently to the Influx database for support the InfluxDataBaseMethods class.
