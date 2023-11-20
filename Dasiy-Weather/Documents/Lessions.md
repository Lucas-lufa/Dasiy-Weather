Multiple Screens 
Class Notes 
Although you can occasionally get away with a single screen app, most apps have multiple screens. In Xamarin, each 
screen is a class with an associated XAML file. For example, the apps you have been working on so far have been 
using an object called “MainPage” that gets its layout from MainPage.xaml. 
Creating a new screen just means creating a new object. Follow these steps… 
 • Right click on the main project in the sidebar on the right, select “Add” and then “New Item”. 
 • Select “Content Page” 
 • Give the new screen a name. 
 The XAML and code behind will be added to your project. 
Opening Another Screen 
Once you have a second screen, the next problem is how to switch back and forth (say, if a button is tapped). Since a screen is a class, the first step is to instantiate an object of that class. Then you need to move to it using a special class called “Navigation” which is provided by Xamarin. The code below shows how to display a second screen (called “ContactPage” in the example). 
 
 ContactPage contactPage = new ContactPage(); 
 await Navigation.PushModalAsync(contactPage); 

Since the push method is “awaited”, remember to make the method in which this code is placed asynchronous. 
That is… 
 async void WhateverTheMethodIsCalled() 
Returning Back to the First Screen 
Returning to the previous screen is once again done with the Navigation class. 
 await Navigation.PopModalAsync(); 

The UI Stack

Why do we “push” and “pop” the screens? 
The user interface is treated like a stack. Imagine a stack of paper that you’re looking down on. A new screen means a new piece of paper is put on the stack, covering up the ones below. Going back means the top piece of paper will be removed, allowing you see the page below. 

A stack is a common design pattern in programming. It’s basically just an array but we only add and remove from one end - the “top”. The screens of your app are stored in such a stack. Yes, but why push and pop? According to legend, the original stack received its name from the spring loaded stacks of dishes in the university cafeteria: you put one on top, and the stack of dishes goes down a bit, you take one away and it pops up a bit. 

The Page Life Cycle 
If you need to do anything with a content page when it is shown on the screen or when it vanishes from the screen, it’s useful to know the life cycle of the page. 

Initialisation 
A page is just an object, like any other object. It can have properties, methods and so on. It is also, like any object, initialised in a constructor. This, for example, is the default constructor for the main page of an empty Xamarin app…

 public MainPage() 
 { 
 InitializeComponent(); 
 } 

The “InitializeComponent()” method (note the American spelling is what loads the XAML file, parses it, initialises all the controls (grids, buttons, labels and so on) and displays them. It’s important to remember this because if you want to do anything with any of those controls, it must be done after InitializeComponent(). Otherwise, they don’t exist yet. OnAppearing() 

Every page is derived from a super class called ContentPage. You can see it right at the top of the class… 

 public partial class MainPage : ContentPage 

ContentPage has a couple of useful lifecycle methods we can override. The first is called “OnAppearing()” and is called as the page is being displayed on the screen. You can override the method and add tasks that you want done when the page appears.

 protected override void OnAppearing() 
 { 
 base.OnAppearing(); 
 // Do whatever you want here 
 }
 
Note that we call the OnAppearing() method for the base class (in this case, ContentPage) before we do anything else. 

OnDisappearing() 
OnDisappearing works the same as OnAppearing except it is called when a page is removed. 
Aside: The App Life Cycle 
The app itself has a series of life cycle methods - OnStart(), OnSleep() and OnResume() which you can find in the 
App.Xaml.cs file in your project. Note that there is no “OnQuit()” method. All apps will sleep before they quit anyway. 