# Net9App

## To Migrate
* default project in Package Manager Console) => Infrastructure
* Set as startup project => Blazor_Server
* EntityFrameworkCore\Add-Migration First
* EntityFrameworkCore\Update-Database

---

## Project Architecture (Clean)
* Models => Domain
* Business (Services - Use Cases) => Application
* DataAccess => Infrastructure
* UI => Presentation
* Common (Dtos) => Shared

![Architecture](/images/clean_architecture.png)

---

## Based on:
[Blazor - The Complete Guide [.NET 9] [E-commerce]](https://www.dotnetmastery.com/Home/Details?courseId=24)
