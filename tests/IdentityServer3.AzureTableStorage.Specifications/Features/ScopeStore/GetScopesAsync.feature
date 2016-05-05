﻿Feature: GetScopesAsync

Background: 
	Given scope table has scopes:
        | Name  | ShowInDiscoveryDocument |
        | read  | true                    |
        | write | true                    |
        | abc   | false                   |

Scenario: publicOnly is true
    Given publicOnly is true
	When ScopeStore.GetScopesAsync(<publicOnly>) is called
	Then the result should scopes:
        | Name  |
        | read  |
        | write |

@ignore
Scenario: publicOnly is false
    Given todo
