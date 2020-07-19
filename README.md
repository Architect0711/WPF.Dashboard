# Readme

#### *Creator: Robert Bantele*  

#### *Last Updated: 2020-07-139*  

I created this Dashboard and Backend Service while I was exploring WCF and WPF in the beginning of 2019. 

----------

## Overview ##

This Project is a Template for an Enterprise Application in WPF using the MVVM Pattern. It implements a modern look & feel while being extensible so it can be used for a broad range of Projects. 

----------

## Get started ##

1. Clone this Repository into a folder of your choice on your machine
2. Clone my Repository 'WPF.Basics' into the same folder
3. Clone my Repository 'EventAggregator' into the same folder
4. Start Visual Studio with admin privileges and open the Solution *WCF.DashboardService.sln* with it
5. Start Visual Studio without admin privileges and open the Solution *WPF.DashboardStarter.sln* with it
6. The Dashboard will connect to the WCF Service automatically and a login screen will be displayed
7. Enter any Username and Password
8. The dummy implementation of the WCF Service will push Status Changes and Messages in random Intervals to the Dashboard
9. Play around with the Settings and the different Views available from the Sidebar Menu. Change the Language and the Color Scheme. The Dashboard can restart itself for Changes to take effect.

----------

# Design Doc

## Context ##

I started this Project for several reasons:

1. I was working with a buggy, unmaintainable WinForms UI at Work and I  had just started developing a new Backend for an important Customer, so naturally, I didn't want to ship my new Backend with a bad Frontend. So I decided to create this Starter on my own time and then build a new Frontend with it.
2. I wanted to do a complex WPF Project to learn more about WPF and MVVM. I had already done a smaller WPF MVVM Project from scratch and (among the other Benefits of WPF over WinForms) really liked the Separation of Concerns between View and ViewModel. 
3. I wanted to have Content to upload to my Github to have something to show for future Job Applications. If that's the reason you're reading this: hire me! :)
4. I wanted to have a well-documented Starter that I can keep developing and use when it's needed.

----------

## Goals ##

1.  Create my own Implementation of the MVVM Design Pattern.
2.  A custom UserControl as Titlebar that can hold a Company Logo and some Text.
3.  A two-part Sidebar that can be extended or hidden and hold two different switchable UserControls.
4.  The View in the main Viewport should also be switchable and the whole look and content of the App should be controllable from a MainWindowViewModel.
5.  The App should have a Skinning Feature.
6.  There should be an Implementation for Localizing the Texts displayed to the User.
7.  An Implementation of the EventAggregator Pattern to communicate between ViewModels.
8.  A (dummy) Login functionality, that will hide parts of the UI until logged in.

----------

## Non-Goals ##

1. Skinning at runtime
2. Implementing any real Business Logic
