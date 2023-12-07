Lucas Fadersen v092953

Mobile-application-knowledge-based-assessment

Q1 – Name two operating systems used in mobile devices and their respective native languages.
(Bullet Points)

- sailfish https://sailfishos.org/
https://docs.sailfishos.org/ 
front end Qt 5, QT Quick2, Waylands.
logic c++ and python are fully supported.

- ubuntu touch https://ubuntu-touch.io/
https://docs.ubports.com/en/latest/
front Qt framework (I assume 5 as well)
c++, Python, Go, Rust or even Javascript for your backend.

Q2 – Discuss the impact of hardware on mobile development including limitations and benefits. (Paragraph)

Mobile devices have three main focuses being on consuming media, creating media and battery. Consuming media is done through the screen, audio is consumed a lot as well but usually use something like headphones or speaker to extend the audio capabilities, this has meant they have become crisper and bigger in order to read and watch videos better. With the creation of media it is mainly though camera making photos and videos so the optical sensor has become great while other input devices, like keyboard are only available through extension. The mobile is always on battery so how the device and applications use power is very important and how to optimise it should alway be considered. From a technological point of view there are no limitations, these have all been solved, when developing for mobile we need to consider how they are being used as I have outlined. This doesn't mean we should stay with in these bounds only but they need to be considered when developing.

Q3 – Discuss how inputs constrain user interface design and the development process when 
compared with desktop and web-based devices, highlighting considerations and how these 
constraints are overcome. (Paragraph)

Most desktop applications have every possible use that has been thought of. If the application is a graphical user interface the UI becomes very cluttered, even all the options with a command line interface can be confusing but they tend to be neatly tucked away. I see most web-based devices strip back to the core functionality and of this functionally it's options are also stripped back in order to fit into input constraints, using an icon or gesture instead of multiple nested menus and this being more focused helps when there are network limitations.

Q4 – Give one example mathematic rule that creates UI designs that are pleasing to the eye.

The golden ratio, also known as the divine proportion.

Q5 – What is Cross-Platform development and how is it used in mobile applications? (Paragraph, 
give at least one example of a tool/framework)

The developer writes their program and the framework dose the work of making sure it will work well one all other platforms supported. For example with " .NET MAUI, you can develop apps that can run on Android, iOS, macOS, and Windows from a single shared code-base."
https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui?view=net-maui-8.0

Q6 – Apart from the above example, provide one other tool/framework that is also open-source.

Flutter is an open-source cross-platform framework for mobile, web and desktop applications.

Q7 – Describe what XAML is, and how it is utilised in open-source cross platform development? (Statement)

Extensible Application Markup Language (XAML) Is a declarative language used to build user interfaces in .net MAUI

Q8 – Give one programming pattern to separate code into different roles when architecting software 
for mobile (Acronym and full name). 

model-view-control (MVC)

Q9 – Discuss how mobile applications utilise web services in their design and implementation. 
(Statement; Give one example of a web technology or service)

Mobile applications can use web services by calling web application programmable interfaces (webAPI). This can give access to data you don't have or functionality that you can't or don't want to be done locally.

The open weather webAPI is an example that I am using.
https://openweathermap.org/current

Q10 – What is a company style guide’s role in the development of application interfaces and UI 
Design? (Paragraph)

Company style guide has two roles, the first is to give all applications, websites and potential even documents a consistence look which helps appearing professional, second the user experience is addressed so in development you don't have to sent time reinventing, it is almost a module import for your design, or forgetting a key part, like accessability.