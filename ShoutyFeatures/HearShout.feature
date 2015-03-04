Feature: Hear shout

  Rules:
  - Must be within 1 km
  - Displayed in order of creation
  - Network and geo location must be enabled
  
  Notes:
  - Display error when no geo or network
  
  Assumption:
  - Everybody has geo location and network
	
  Scenario: Phil can't hear Jeff who is far away
	Given Jeff is in the Norwich Castle
	And Phil is in Washington DC
	When Jeff shouts
	Then Phil should not hear Jeff's shout

  Scenario: Phil can hear Sally who is within range
	Given Sally is in the Norwich Castle
	And Phil is in the Bell Hotel Norwich
	When Sally shouts
	Then Phil should hear Sally's shout

  Scenario: Jeff shouts after Lisa shouts

  Scenario: Jeff and Lisa shout at the same time
