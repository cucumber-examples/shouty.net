Feature: Shout and receive a shout

As a user of Shouty
I want to shout a message to the users near to me
So that I can share some important local information

Rules:
- Shout can be heard within 1000m
- The shout should be less than 2000 letters
	
Scenario: Receiver is within range
	Given Joe is 580m away from Mary
	When Mary shouts "Free vlaai!!!"
	Then Joe should receive "Free vlaai!!!"

@wip
Scenario: Receiver is out of range
	Given Joe is 1100m away from Mary
	When Mary shouts "Free vlaai!!!"
	Then Joe should not receive "Free vlaai!!!"

