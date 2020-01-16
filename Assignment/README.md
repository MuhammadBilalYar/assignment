# Version 2
## Thread Management
Added thread pool to handle minimum and maximal threads, initial it will create thread pool with minimum 3 threads and maximum 5 threads which are default configuration. But I fix the number of objects that single thread will process which are 50. Like each thread is responsible of extracting 50 objects. If number of available objects are greater than Max thread (default), it will calculate new Max thread num by simply total objects/object per threads. Then it will update Max thread number in thread pool. After that I am starting each thread to pull mentioned portion from API. 

## Memory Management
As we can’t hold millions of objects in the memory. So, instead of holding it to memory I created an importer part that is responsible for pushing retrieved data to a file and then flush that data from memory. Each thread will open file in append mode and after added its stuff it will close the file.


# Version 1
This solution include these two projects

# Assignment
	Main project that dealing with API and its thread

## ConfigManager.cs
	A utility for loading configuration from appsetting.json file 

## ApiClient.cs
	A utility that call API service for checking available objects and then simulate API call to pull availble objects
	
## Program.cs
	Project starting point


# Assignment.Test
	This project contain unit tests

## ConfigManager.Test.cs
	containe unit tests for configuration manager (ConfigManager.Test.cs)

## ApiClient.Test.cs
	containe tests realted to mock api (ApiClient.cs)