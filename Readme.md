This project has some specflow scenarios to test functionalities with selenium, 
apis, mongodb, file copying, and excel files iteractions tests.

The tests have the nunit framework and can be executed in parallel. With this 
configuration the browser will be closed after each selenium test and each
test will be executed in a new browser.

Requirements:
    - Visual Studio 2019
    - Specflow extension for visual studio 2019
    - .net framework 4.8

Project configuration:
- Select one of the runsettings located in the Shared folder:
    - parallel.runsettings -> to execute the tests in parallel
    - serial.runsettings -> to execute the tests in serie
    
        When running the test in serie it is possible to make the selenium tests reuse the browser. 
		This behaviour is only possible with chrome actually. With the rest of the browsers there are errors.
        To configure if the browser is going to be reusing the browser, you have to
        set to true the parameter ReuseBrowser in the file App.config in the SpecflowTests
        project.
        
- Execute the three reg files located in the Setup folder to be able to use the Internet Explorer browser to run the tests

- Select the desired browser in the dropdown of the configuration manager

- Execute the tests from the test explorer



---- How to run tests in command line
---- create a project for each helper
---- create ios class in the webdriverhelper setup class