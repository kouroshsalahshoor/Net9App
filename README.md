# Net9App

## To Migrate
* default project in Package Manager Console) => Infrastructure
* Set as startup project => Blazor_Server
* EntityFrameworkCore\Add-Migration First
* EntityFrameworkCore\Update-Database

---
# bunit
## install
in solution folder:
> dotnet new install bunit.template
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

### Blazor
* [Blazor - The Complete Guide [.NET 9] [E-commerce]](https://www.dotnetmastery.com/Home/Details?courseId=24)
* [Udemy – Handling Long-Running Tasks in .NET Core 2023-7](https://downloadlynet.ir/2024/04/134079/08/handling-long-running-tasks-in-net-core/19/?#/134079-udemy-132411112126.html)
* [Pluralsight – ASP.NET Core 6 Blazor Fundamentals 2022-10](https://downloadlynet.ir/2024/01/127564/06/asp-net-core-6-blazor-fundamentals/19/?#/127564-pluralsi-122428115629.html)
* [BethanysPieShopHR](https://github.com/GillCleeren/BethanysPieShopHR)
* [blazor-workshop](https://github.com/dotnet-presentations/blazor-workshop?tab=readme-ov-file)

### Architecture
* [Pluralsight – ASP.NET Core 6 Clean Architecture 2022-12](https://downloadlynet.ir/2023/18/93765/03/asp-net-core-6-clean-architecture/21/?#/93765-pluralsi-022450112828.html)

### Authors
* adam freeman
* Bhrugen Patel
* gill cleeren
* kevin dockx
* Felipe Gavilán
* Ervis Trupja
