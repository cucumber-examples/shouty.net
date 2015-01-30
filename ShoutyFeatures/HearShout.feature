Feature: Hear shout
	
  Scenario: Listener is within range
    Given Lucy is 15 metres from Sean
    When Sean shouts "Free bagels!"
    Then Lucy hears Sean's message