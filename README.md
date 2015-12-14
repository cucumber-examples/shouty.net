# Shouty

Shouty is a social networking application for short physical distances.
When someone shouts, only people within 100m can hear it.

Shouty doesn't exist yet - you will implement it yourself!

That is, if you're attending a BDD/Cucumber course.

## Agenda

### Get the code

You'll be working on a branch of the repository that has been set up for the
training. This allows you to catch up with the trainer's code throughout the day.

Substitute `THEBRANCH` below with what the trainer tells you.
It's usually today's date, followed by the trainer's initials: `YYYY-MM-DD-FL`.

Git:

    git clone https://github.com/cucumber-ltd/shouty.net.git
    cd shouty.net
    git checkout THEBRANCH

Subversion:

    svn checkout https://github.com/cucumber-ltd/shouty.net/branches/THEBRANCH shouty.net
    cd shouty.net

Or simply [download](https://github.com/cucumber-ltd/shouty.net/releases) a zip or tarball.

### Catch up!

Throughout the day - if you want to catch up with what the trainer has pushed to this
branch, simply do:

    git reset --hard  # This blows away your local changes
    git pull          # This updates your working copy with the latest code

### Set up environment

* Install Visual Studio
    * [Community Edition](http://www.visualstudio.com/en-us/news/vs2013-community-vs.aspx) if eligible
* Install SpecFlow integration ([VS2013](http://www.specflow.org/documentation/Visual-Studio-2013-Integration/))
* Install [NUnit Test Adapter](https://visualstudiogallery.msdn.microsoft.com/6ab922d0-21c0-4f06-ab5f-4ecd1fe7175d)
* Open Shouty.NET solution in visual studio
* Select Test > Run > All Tests from the menu, or press `CTRL-R, A`

### Brainstorm capabilities

* Who are the main stakeholders?
* What can people do with the app?
* What are the main differentiators from other apps?

### Pick one capability

* Define rules
* Create high level examples (Friends episodes)

Then do this for each example to discover more examples:

* Can you think of a context where the outcome would be different?
* Are there any other outcomes we haven't thought about?

### Implement one capability. Text UI only.

* Write a Cucumber Scenario for one of the examples
* Make it pass!
