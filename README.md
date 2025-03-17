#### Goals:
This assessment is somewhat large and has many facets to it. There are no must haves
and you can implement as much as you feel comfortable doing. The goal is to be able to
assess your skills in understanding and clarifying requirements and your general
approach to coding and logic.
You may be challenged during the interview to add / change features on the fly, so please
avoid “Spaghetti code” copy paste - the code should be well structured and extensible.
Scenario:

### MP has teams of salespeople out on the field selling our renewable energy products. Each morning the sales teams get into the team vans and travel out to their assigned sales area.
Instead of the sales teams walking around their assigned area - we want the vans drop
them off at a CitiBike location and they then use the bikes to travel around.
At the end of the day - the teams drop their bikes off at CitiBike locations and the vans
come around and pick them up and bring them back home.


#### Requirements:
The new functionality we want to build is a system that can interface with the CitiBike API
and help the sales teams find citibike stations:


### The system will have 2 modes of operations:
#### Morning mode:
For each team - the system will accept Lat,Long coordinates of the center of their sales
territory for that day. The system will then query the CitiBike API to determine the closest
CitiBike station to that location that has enough bikes for that whole team.
The team van driver should not be assigned a bike and not included in the calculations

#### Evening mode:
For each team - the system will accept a Lat,Long of the teams current location. The system
will then query the CitiBike API to determine the closest CitiBike station. If the closest
station does not have enough available docks for the entire team then the system should
assign the longest serving team members to this station and then continue searching
outwards for stations that can accommodate the remaining team members based on
seniority.


#### The team van drivers should be assigned to the station that has the most team members assigned to so that he can begin his pickup route.
● We need to be able to run the system in both modes multiple times a day with the
CitBike data current to when it was run (if not in test mode as specified below)
● User interface can be a simple console application
● In morning mode if there are no stations that have the number of bikes required
for a team - print a notification
● Deconflicting teams at stations (if team 1 and 2 are assigned to the same station)
is not required at this time
● Distance is defined as point to point “as the crow flies” irrespective of
geographical features such as rivers etc…
● Your code should have the capability to switch CitiBike data sources between
Live and Test data.
● Multithreading would be nice but not required
● Inputs should be validated and when in error halt execution and provide a
detailed description of the error
● The input file with all of the agents (Teams.csv) and teams will always be
ordered by agent id