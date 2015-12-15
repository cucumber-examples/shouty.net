Feature: User hears shout

	In order to hear some cool and useful info
	Lucy should be able to hear Bob shouting
	about free stuff in her area

	Rules
	=====

	- People must be 1000m or closer to hear each other
	- Only consider shouts as happening immediately

  Scenario: Lucy doesn't hear Bob as she is 1100m away
	Given Lucy and Bob are 1100m apart
	When Bobs shouts "Free stuff!"
	Then Lucy doesn't hear anything

  Scenario: Lucy hears Bob as they are only 400m apart
	Given Lucy and Bob are 400m apart
	When Bobs shouts "Free stuff!"
	Then Lucy hears "Free stuff!"