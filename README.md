# Concurrent programming

## Working Group

| Name Surname (initials) | GUID                                     |
| ----------------------- | ---------------------------------------- |
| MP                      | `01e159af-4124-4c3e-bcdf-50dd80c893b9`   |
| MS                      | `e7e52d02-af97-4a39-8b51-0a6180b22eaa` |

## Create a repository checklist
ETAP - 1
- [X] text is in C#
- [X] build succeeded
- [X] all UT are green
- [X] `Data` layer is clearly stated using language terms only (no database, no file)
- [X] `Data` API is clearly stated
- [X] `Data` API is abstract
- [X] `Logic` layer is clearly stated using language terms only
- [X] `Logic` API is clearly stated
- [X] `Logic` uses only the abstract `Data` layer API
- [X] `Presentation` layer is clearly stated using language terms only
- [X] `Presentation` uses only the abstract `Logic` layer API
- [X] MVVM and XAMLare applied to implement GUI
- [X] reactive and interactive user interaction for user (operator) communication
- [X] reactive and interactive programming is used for the communication of layers 
- [X] `Presentation` - object model representing process data
- [X] Fulfill functional requirements of the task
- [X] Unit Test - layers are tested independently using abstract API
- [ ] Dependency injection (additional framework is not required)
- [X] Mock is used for testing purposes (expected but not required)

ETAP - 0
- [X] the task provides required feedback and has been submitted (needs grading)
- [X] the ability to clone the repository to the teacher's computer
- [X] there is README.md formatted as expected
- [X] `README.md` contains required information
- [X] build succeeded
- [X] all UTs are green
