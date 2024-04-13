# Concurrent programming

## Working Group

| Name Surname (initials) | GUID                                     |
| ----------------------- | ---------------------------------------- |
| MP                      | `01e159af-4124-4c3e-bcdf-50dd80c893b9`   |
| MS                      | `e7e52d02-af97-4a39-8b51-0a6180b22eaa` |

## Create a repository checklist
ETAP - 1
- [X] text is in C#
- [ ] build succeeded
- [ ] all UT are green
- [ ] `Data` layer is clearly stated using language terms only (no database, no file)
- [ ] `Data` API is clearly stated
- [ ] `Data` API is abstract
- [ ] `Logic` layer is clearly stated using language terms only
- [ ] `Logic` API is clearly stated
- [ ] `Logic` uses only the abstract `Data` layer API
- [ ] `Presentation` layer is clearly stated using language terms only
- [ ] `Presentation` uses only the abstract `Logic` layer API
- [ ] MVVM and XAMLare applied to implement GUI
- [ ] reactive and interactive user interaction for user (operator) communication
- [ ] reactive and interactive programming is used for the communication of layers 
- [ ] `Presentation` - object model representing process data
- [ ] Fulfill functional requirements of the task
- [ ] Unit Test - layers are tested independently using abstract API
- [ ] Dependency injection (additional framework is not required)
- [ ] Mock is used for testing purposes (expected but not required)

ETAP - 0
- [X] the task provides required feedback and has been submitted (needs grading)
- [X] the ability to clone the repository to the teacher's computer
- [X] there is README.md formatted as expected
- [X] `README.md` contains required information
- [X] build succeeded
- [X] all UTs are green
