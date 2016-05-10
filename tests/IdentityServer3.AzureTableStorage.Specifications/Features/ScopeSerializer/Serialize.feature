Feature: Serialize

Scenario: Happy path
	Given a Scope object
	When ScopeSerializer.Serialize(scope) is called
    Then a DynamicTableEntity should be returned
	And DynamicTableEntity.PartitionKey should be Scope.Name
	And DynamicTableEntity.RowKey should be empty string
    And DynamicTableEntity.Properties should include all Scope properties except Scope.Name
