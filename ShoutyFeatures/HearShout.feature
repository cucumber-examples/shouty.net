Feature: Hear shout
	
  In order to send location-sensitive messages to people nearby
  As a shouter
  I want to broadcast messages to people near me

  Rules:
    - broadcast to all users
    - don't worry about proximity yet

  Background:
    Given the range is 100
    And the following people:
      | name  | location |
      | Lucy  | 100      |
      | Sean  | 0        |
      | Larry | 150      |

  Scenario: Listener hears a message
    When Sean shouts "Free bagels!"
    Then Lucy hears Sean's message

  Scenario: Listener hears a different message
    When Sean shouts "Free coffee!"
    Then Lucy hears Sean's message

  Scenario: Listener is within range
    When Sean shouts "Free bagels!"
    Then Lucy hears Sean's message

  Scenario: Listener is out of range
    When Sean shouts "Free coffee!"
    Then Larry does not hear Sean's message