# Net9App

![Architecture](/images/clean_architecture.png)
---

## Project Architecture (Clean)
* Models => Core = Domain
* Business (Services - Use Cases) => Application
* DataAccess => Infrastructure
* UI => Presentation
* Common (Dtos) => Shared
---

## To Migrate
* default project in Package Manager Console) => Infrastructure
* Set as startup project => Blazor_Server
* EntityFrameworkCore\Add-Migration First
* EntityFrameworkCore\Update-Database

---
## Subjects:
- [x] Blazor
- [x] Clean Architecture
- [x] XUnit
- [x] AutoFixture
- [x] Fluent Assertion
- [x] BUnit
- [x] Selenium
- [x] Specflow
- [ ] identity
- [x] Long-Running Tasks
- [x] Hangfire
- [x] azure AD
- [ ] ci cd
- [x] docker
- [x] Kubernetes
- [x] kind
- [x] Typescript
- [x] Node
- [ ] React
- [ ] Angular
- [ ] Vue
- [ ] Design Patterns
- [ ] Reflection
---
# bunit
## install
in solution folder:
> dotnet new install bunit.template

---
## Kubernetes
https://kind.sigs.k8s.io/docs/user/quick-start#installing-from-release-binaries

> C:\kind>kind
> C:\kind>kind create cluster --name k8s-course

> kubectl get nodes
> kubectl get pods --all-namespaces
> kubectl get services --all-namespaces
> kubectl get services --namespace kube-system
> kubectl get deployments --all-namespaces
> kubectl get namespaces

> kubectl create ns my-namespace
> kubectl create deployment my-website --image=nginx --port=80 --replicas=3 --namespace my-namespace
> kubectl expose deployment my-website --port=80 -n my-namespace

Wait for the deployment to be ready
> kubectl rollout status deployment/my-website

Port forward to the service so we can access from our host
(there are other ways - but we'll cover that later in this course)
> kubectl port-forward service/my-website 8080:80 -n my-namespace

If you want to cleanup, run this command after you're done...
> kubectl delete ns my-namespace

C:\Users\kouro\.kube\config

List all contexts
> kubectl config get-contexts

Switch context
> kubectl config use-context my-context

Check current context
> kubectl config current-context

> Create new context
kubectl config set-context my-context --cluster=<cluster-name> --user=<user-name> --namespace=<namespace>

Set namespace for current context
> kubectl config set-context --current --namespace=my-namespace

---

## Based on:

### Blazor
* [Blazor - The Complete Guide [.NET 9] [E-commerce]](https://www.dotnetmastery.com/Home/Details?courseId=24)
* [Udemy – Handling Long-Running Tasks in .NET Core 2023-7](https://downloadlynet.ir/2024/04/134079/08/handling-long-running-tasks-in-net-core/19/?#/134079-udemy-132411112126.html)
* [Pluralsight – ASP.NET Core 6 Blazor Fundamentals 2022-10](https://downloadlynet.ir/2024/01/127564/06/asp-net-core-6-blazor-fundamentals/19/?#/127564-pluralsi-122428115629.html)
* [BethanysPieShopHR](https://github.com/GillCleeren/BethanysPieShopHR)
* [blazor-workshop](https://github.com/dotnet-presentations/blazor-workshop?tab=readme-ov-file)

### Test
* [Udemy – Advanced Automation Testing of Modern Apps with C# .NET 2022-12](https://downloadlynet.ir/2024/20/121451/03/advanced-automation-testing-of-modern-apps-with-c-net/21/?#/121451-udemy-092454125903.html)

### Architecture
* [Pluralsight – ASP.NET Core 6 Clean Architecture 2022-12](https://downloadlynet.ir/2023/18/93765/03/asp-net-core-6-clean-architecture/21/?#/93765-pluralsi-022450112828.html)

### Kubernetes
[Dometrain – From Zero to Hero: Kubernetes for Developers 2024-6](https://downloadlynet.ir/2024/24/132804/07/from-zero-to-hero-kubernetes-for-developers/13/?#/132804-dometrai-112449122301.html)

### Authors
* [adam freeman](https://www.ebooksworld.ir/search?term=adam+freeman)
* [Bhrugen Patel](https://downloadlynet.ir/?s=Bhrugen+Patel)
* [gill cleeren](https://downloadlynet.ir/?s=gill+cleeren&post_type%5B%5D=post&post_type%5B%5D=download)
* [kevin dockx](https://downloadlynet.ir/?s=kevin+dockx&post_type%5B%5D=post&post_type%5B%5D=download)
* [Felipe Gavilán](https://downloadlynet.ir/?s=Felipe+Gavil%C3%A1n&post_type%5B%5D=post&post_type%5B%5D=download)
* [Ervis Trupja](https://downloadlynet.ir/?s=Ervis+Trupja&post_type%5B%5D=post&post_type%5B%5D=download)
* [Dometrain](https://downloadlynet.ir/?s=Dometrain)
* Thomas Claudius Huber
* Alex Wolf
* Roland Guijt
* Trevoir Williams

### Books
[ebooksworld](https://www.ebooksworld.ir/)

### Resources
- [Dot Net Mastery](https://www.dotnetmastery.com/)
- Udemy
- Pluralsight
- Dometrain
