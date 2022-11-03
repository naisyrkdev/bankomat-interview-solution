# bankomat-interview-solution

#### ## # Backend Solution - how to run

To run backend solution set-up **WebAPI **project as **start-up project**.

Next add first initial migrations by typing in Nuget Package Manager Console (set **Infrastructure** as default project in console):
`add-migration init`
after succesfully created migration run:
`update-database`

Now you can successfully build and run solution.

The user is mocked, there is no authentication nor authorization. 

If you want access /bank-account/withdraw-money use BankomatId: 1 and BankAccount: 1.

Also recommend to use Swagger for API documentation and testing.
Access: *-YourHostURL-*/swagger


Potential problems:
-If with current ConnectionString you cannot create migration you can change it in the **WebAPI** project => appsettings.json

### ## # Frontend solution - how to run
See:
https://github.com/naisyrkdev/bankomat-interview-solution/tree/main/src/Frontend/bankomat-client-project