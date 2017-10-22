# BuildIt.Tests
Creating acceptance tests using Selenium

# How to build

1. Be sure Weather Forecast is running locally.
2. Edit the app config file to use the correct host and port. 
3. Open solution in Visual Studio to run tests 
  Alternatively, if you build solution, you can run tests using command line command: mstest /testcontainer:UI.Weather.Tests.dll
  
# Given more time
  
My first thought is that if I had already had a Selenium framework in place, I would have been able to make the tests much quicker and with greater confidence of stability. However, I only made a simple implementation of it without many things that I would usually like to have.

With more time I would have created more acceptance test cases and would have automated most of them. There were things that required more work to be able to automate more of the criteria. Such as dealing with icons, verifying test data, as well as creating more data to achieve different expected results along with setting up a json reader to more easily validate the mocked test data.

