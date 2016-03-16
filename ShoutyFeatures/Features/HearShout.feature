@web
Feature: Hear shout

Rules:
	- if the shouter is within 1km of the listener, the listener hears the shout
	- if the shouter is more than 1km away from the listener, the listener doesn’t hear the shout
	- the message can’t be empty
	- the message must be shorter than 140 characters
 
Questions:
	- what happens if the listener arrives 5 minutes after a shout?
	- what happens in two dimensions?

@done
Scenario: Out of range shout is not heard
    Given Linda is at [0, 0]
    And Fred is at [0, 1100]
	When Fred shouts
	Then Linda should hear nothing

@done
Scenario: In range shout is heard
    Given Linda is at [0, 0]
    And Fred is at [0, 800]
	When Fred shouts
	Then Linda should hear Fred’s shout