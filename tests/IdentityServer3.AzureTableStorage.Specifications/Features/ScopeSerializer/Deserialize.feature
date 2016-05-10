Feature: Deserialize

Scenario: Happy path
	Given a DynamicTableEntity object from the Scopes table
	When ScopeSerializer.Deserialize(row) is called
    Then a Scope object should be returned
    And the Scope properties should be initialized from the DynamicTableEntity

@ignore @todo
Scenario: Missing properties
	Given todo

@ignore @todo
Scenario: Additional properties
	Given todo
