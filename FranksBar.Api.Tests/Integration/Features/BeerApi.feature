@Integration
Feature: Beer Api
	Creating, updating and retrieving beer

Scenario: Beer - Creating invalid without name
	Given a beer has a name of '' and alcohol percentage of 5%
	When beer command is posted
	Then BadRequest response with the following errors
		| ErrorMessage                     |
		| Please specify name of the beer. |

Scenario: Beer - Creating invalid without percentage
	Given a beer has a name of 'Epic Beer' and alcohol percentage of -1%
	When beer command is posted
	Then BadRequest response with the following errors
		| ErrorMessage                                              |
		| 'Percentage Alcohol By Volume' must be greater than '-1'. |
