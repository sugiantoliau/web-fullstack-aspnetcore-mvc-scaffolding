# web-fullstack-aspnetcore-mvc-scaffolding

### Development Tools
- develop using visual studio 2026

- using dotnet framework 10.0

- using database of sqllite


### Install Database Tools
Go to Tools > NuGet Package Manager > Package Manager Console

```bash
Install-Package Microsoft.EntityFrameworkCore.Sqlite
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.Tools
```


###  Setting database folder and database name
- create new folder "database"

- Open your appsettings.json and add the command:
```bash
{
    "ConnectionStrings": {    
    "DefaultConnection": "Data Source=database/standalone.db",
    }, 
}
```


###  Setting data folder

- create new folder "data"

- create file "ApplicationDbContext.cs"

```bash
using Microsoft.EntityFrameworkCore;
using YourProjectName.Models;

namespace YourProjectName.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // This creates a database table named "Customers"
        public DbSet<Customer> Customers { get; set; }
    }
}
```


- change the Program.cs and add the commands:

```bash
using web_fullstack_aspnetcore_mvc.Data;
```

```bash
// Add services to the data
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
```



###  Run Your Migration Commands

Open your Package Manager Console (Tools > NuGet Package Manager > Package Manager Console

```bash
Add-Migration InitialCreate
```

```bash
Update-Database
```

if you found an error: The running command stopped because the preference variable "ErrorActionPreference" or common parameter is set to Stop: System.Management.Automation.RemoteException", run this command on  Package Manager Console, run the command at Package Manager Console:

```bash
$ErrorActionPreference = "Continue"
```


### Trigger Scaffolding 
- Right-click your Controllers folder and select Add > New Scaffolded Item

- Choose MVC Controller with views, using Entity Framework

- Set the configuration values exactly like this:

    - Model Class: Choose Customer (YourProjectName.Models)

    - DbContext Class: Choose ApplicationDbContext (YourProjectName.Data)

    - Controller Name: Leave it as CustomersController


### Add a country drop down list when creating a new Customers 


- open file at "Controllers\CustomersController.cs" and modify this code
 
 ```bash
// GET: CUSTOMERS/Create
    public IActionResult Create()
    {
        // Populate the dropdown options
        ViewBag.Countries = new List<string> { "United States", "Canada", "United Kingdom", "Australia", "Indonesia" };
        

        return View();
    }
```
 
- open file at "\Views\Customers\Create.cshtml" and modify this code


- Find the code below and delete it

 ```bash
<div class="form-group">
    <label asp-for="Country" class="control-label"></label>    
    <span asp-validation-for="Country" class="text-danger"></span>
</div>
```

- add this code to replace the deleted code 
```bash
<div class="form-group">
    <label asp-for="Country" class="control-label"></label>            
    <select asp-for="Country" class="form-control" asp-items="@(new SelectList(ViewBag.Countries))">
        <option value="">-- Select Country --</option>
    </select>
    <span asp-validation-for="Country" class="text-danger"></span>
</div>
```

### Run the App by Pressing F5

- Press F5 to run your application.

- When the browser opens, type /Customers/Create at the very end of your URL (e.g., https://localhost:7123/Customers/Create).


### Enjoy

