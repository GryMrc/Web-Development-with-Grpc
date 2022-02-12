# Problems
When I get http response error , should check database connection may be it necessary sign up again.

# **To Do**

1-) When entered username with lowercase or uppercase it is returning true response from database( Update: Usernames are not case sensitive every form so wont fix this.)

2-) Create two admin user for listing which admin create which models.

3-) Database operations should try catch to capture error and every critical sections should check with if conditions.

4-) Prevent register on Login Screen (solution Register Action Screen define Privilege Admin User)

5-) Name fields on entities must be not null

6-) Deleting privilege deletes users table with assosiacted.( solution: Making deletebehaviour restrict assign null value to not null column throws db exception maybe this can help)

7-) gRPC error handling

8-) If viewmodel consist less properties gives mapper error (Why?)

9-) Base Form class will be created

10-) Otomatik Id?? dont send Id variable while creating Country 