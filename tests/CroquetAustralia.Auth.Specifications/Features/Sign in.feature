Feature: Sign in

Scenario: Registered user signs in with valid email address & password
    Given email address 'dummy@example.com'
    And password 'dummy password'
    And is registered user
    When user signs in with email address and password
    Then the user can successfully get results from a secure webapi endpoint

@ignore @todo
Scenario: User attempts to sign in with unknown email address
    Given todo

@ignore @todo
Scenario: Registered user attempts to sign in with incorrect password
    Given todo

@ignore @todo
Scenario: Disabled user attempts signs in with valid email address & password
    Given todo

@ignore @todo
Scenario: Registered user signs in with Google account
    Given todo

@ignore @todo
Scenario: User attempts to sign in with unknown Google account
    Given todo
