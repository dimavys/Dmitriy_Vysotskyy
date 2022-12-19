Feature: Create job title
    Feature which allows user to insert new job title

    Scenario: Successful insertion
        Given User logged in as admin
        And User clicked on Admin Module
        And User clicked on Job Titles
        And User clicked on Add Job Title 
        And User filled all required fileds
        When User clicks Add 
        Then A request is sent
        And User gets request status