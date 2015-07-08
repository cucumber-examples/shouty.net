Feature: Hear shout

  Rules:

  - max length of message is 145 characters (TODO)
  - distance of 100m (TODO)
  - messages are not stored - you have to be within range when the shout is sent to hear it (TODO)

  Scenario: Listener hears the shout
	Given a person named Sean
	And a person named Lucy
	When Sean shouts "Free Bagels!"
	Then Lucy hears "Free Bagels!"
