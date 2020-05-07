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

The program is based on Windows Forms using the Metro Framework.

# The program is presented in the form of 5 main forecast algorithms:

1. Copying the previous day's values

This algorithm outputs data that was received 24 hours ago as a forecast.

2. Copying the same day a week ago

This algorithm returns the value received 7 days ago on the time line.

3. Combination of algorithms 1 and 2

This algorithm is the second most accurate among the presented ones. We set the coefficients a and b and start changing their values in increments of 0.01. We calculate the RMSE for the obtained values and use the sorting method to find the smallest (closest to 0), then save the coefficient values. The cycle continues until the RMS change is greater than the coefficient change step.

4. Autoregression ML.Net

This algorithm is based on the ML library.Net using ML.Net builder by the Price prediction method. The placemark is a list of historical values of a time series, and the factors are the results of the forecast of other algorithms for that day. The average RMSE of this algorithm is ~1.7
This algorithm is the most accurate of all presented.

5. The "10 out of 10" method

This algorithm calculates the arithmetic mean for the last 10 days. This method is used in some companies. But, unfortunately, this method is the least accurate among those presented for the original set of test data.

