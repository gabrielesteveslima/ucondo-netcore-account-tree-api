# DDD (Domain-driven Design)

Scrum is an agile methodology that allows the team to organize and execute their tasks in an agile manner.

But Scrum does not work in the same way for all teams and projects, we implement the ideas and concepts in the way that makes more sense for our context. DDD works in the same way, there are some concepts that only make sense in enterprise applications (very big applications).

The main advantage of Domain Driven Design is being able to create code with well-defined components that have clear contracts between them. This allows us to better define their responsibilities, makes updating or replacing one of these components much easier with less impact on the overall system.

## Directory Structure

```bash
├── docs (documentation of project)
├── src (main)
│   ├── UCondoAccountTree.Application
│   │   ├── **/*.cs (represents classes of handler presentation layer)
│   ├── UCondoAccountTree.Domain
│   │   ├── **/*.css (represents classes of domain/bussines logic)
│   ├── UCondoAccountTree.Infrastructure
│   │   ├── **/*.css (represents classes of communication with database)
│   ├── UCondoAccountTree.WebAPI
│   │   ├── **/*.css (represents classes of presentation and contracts communication)
│   └── partials/template
├── tests (unit tests of domains)
├── .gitignore
├── LICENSE
└── README.md
```