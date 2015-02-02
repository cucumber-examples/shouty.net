Feature: Hear shout
	
  In order to send location-sensitive messages to people nearby
  As a shouter
  I want to broadcast messages to people near me

  Rules:
    - broadcast to all users
    - don't worry about proximity yet

  Todo:
    - only shout to people within a certain distance

  Scenario: Listener hears a message
    Given a person named Lucy
    And a person named Sean
    When Sean shouts "Free bagels!"
    Then Lucy hears Sean's message

  Scenario: Listener hears a different message
    Given Lucy is 15 metres from Sean
    When Sean shouts "Free coffee!"
    Then Lucy hears Sean's message

  Scenario: Listener is within range

  Scenario: Listener is out of range