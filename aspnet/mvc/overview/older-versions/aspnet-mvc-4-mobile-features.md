---
title: "ASP.NET MVC 4 Mobile Features | Microsoft Docs"
author: Rick-Anderson
description: "There is now an MVC 5 version of this tutorial with code samples at Deploy an ASP.NET MVC 5 Mobile Web Application on Azure Web Sites ."
ms.author: riande
manager: wpickett
ms.date: 08/15/2012
ms.topic: article
ms.assetid: 
ms.technology: dotnet-mvc
ms.prod: .net-framework
msc.legacyurl: /mvc/overview/older-versions/aspnet-mvc-4-mobile-features
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\mvc\overview\older-versions\aspnet-mvc-4-mobile-features.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/24915) | [View dev content](http://docs.aspdev.net/tutorials/mvc/overview/older-versions/aspnet-mvc-4-mobile-features.html) | [View prod content](http://www.asp.net/mvc/overview/older-versions/aspnet-mvc-4-mobile-features) | Picker: 27553

ASP.NET MVC 4 Mobile Features
====================
by [Rick Anderson](https://github.com/Rick-Anderson)

> There is now an MVC 5 version of this tutorial with code samples at [Deploy an ASP.NET MVC 5 Mobile Web Application on Azure Web Sites](https://azure.microsoft.com/en-us/documentation/articles/web-sites-dotnet-deploy-aspnet-mvc-mobile-app/).


This tutorial will teach you the basics of how to work with mobile features in an ASP.NET MVC 4 Web application. For this tutorial, you can use [Visual Studio Express 2012](https://www.microsoft.com/visualstudio/11/en-us/products/express) or Visual Web Developer 2010 Express Service Pack 1 (&quot;Visual Web Developer or VWD&quot;). You can use the professional version of Visual Studio if you already have that.

Before you start, make sure you've installed the prerequisites listed below.

- [Visual Studio Express 2012](https://www.microsoft.com/visualstudio/11/en-us/products/express) (recommended) or Visual Studio Web Developer Express SP1. Visual Studio 2012 contains ASP.NET MVC 4. If you are using Visual Web Developer 2010, you must install [ASP.NET MVC 4](https://go.microsoft.com/fwlink/?LinkId=243392).

You will also need a mobile browser emulator. Any of the following will work:

- [Windows 7 Phone Emulator](https://msdn.microsoft.com/en-us/library/ff402563(VS.92).aspx). (This is the emulator that's used in most of the screen shots in this tutorial.)
- Change the user agent string to emulate an iPhone. See [this](http://www.howtogeek.com/113439/how-to-change-your-browsers-user-agent-without-installing-any-extensions/) blog entry.
- [Opera Mobile Emulator](http://www.opera.com/developer/tools/mobile/)
- [Apple Safari](http://www.apple.com/safari/download/) with the user agent set to iPhone. For instructions on how to set the user agent in Safari to "iPhone", see [How to let Safari pretend it's IE](http://www.davidalison.com/2008/05/how-to-let-safari-pretend-its-ie.html) on David Alison's blog.

Visual Studio projects with C# source code are available to accompany this topic:

- [Starter project download](https://go.microsoft.com/fwlink/?linkid=228307&amp;clcid=0x409)
- [Completed project download](https://go.microsoft.com/fwlink/?linkid=228306&amp;clcid=0x409)

### What You'll Build

For this tutorial, you'll add mobile features to the simple conference-listing application that's provided in the [starter project](https://go.microsoft.com/fwlink/?LinkId=228307). The following screenshot shows the tags page of the completed application as seen in the [Windows 7 Phone Emulator](https://msdn.microsoft.com/en-us/library/ff402563(VS.92).aspx). See [Keyboard Mapping for Windows Phone Emulator](https://msdn.microsoft.com/en-us/library/ff754352(v=vs.92).aspx) to simplify keyboard input.

[![p1_Tags_CompletedProj](aspnet-mvc-4-mobile-features/_static/image2.png)](aspnet-mvc-4-mobile-features/_static/image1.png)

You can use Internet Explorer version 9 or 10, FireFox or Chrome to develop your mobile application by setting the [user agent string](http://www.howtogeek.com/113439/how-to-change-your-browsers-user-agent-without-installing-any-extensions/). The following image shows the completed tutorial using Internet Explorer emulating an iPhone. You can use the Internet Explorer F-12 developer tools and the [Fiddler tool](http://www.fiddler2.com/fiddler2/) to help debug your application.

![](aspnet-mvc-4-mobile-features/_static/image3.png)

### Skills You'll Learn

Here's what you'll learn:

- How the ASP.NET MVC 4 templates use the HTML5 `viewport` attribute and adaptive rendering to improve display on mobile devices.
- How to create mobile-specific views.
- How to create a view switcher that lets users toggle between a mobile view and a desktop view of the application.

### Getting Started

Download the conference-listing application for the starter project using the following link: [Download](https://go.microsoft.com/fwlink/?LinkId=228307). Then in Windows Explorer, right-click the *MvcMobile.zip* file and choose **Properties**. In the **MvcMobile.zip Properties** dialog box, choose the **Unblock** button. (Unblocking prevents a security warning that occurs when you try to use a *.zip* file that you've downloaded from the web.)

![p1_unBlock](aspnet-mvc-4-mobile-features/_static/image4.png)

Right-click the *MvcMobile.zip* file and select **Extract All** to unzip the file. In Visual Studio, open the *MvcMobile.sln*file.

Press CTRL+F5 to run the application, which will display it in your desktop browser. Start your mobile browser emulator, copy the URL for the conference application into the emulator, and then click the **Browse by tag** link. If you are using the Windows Phone Emulator, click in the URL bar and press the Pause key to get keyboard access. The image below shows the *AllTags* view (from choosing **Browse by tag**).

[![p1_browseTag](aspnet-mvc-4-mobile-features/_static/image6.png)](aspnet-mvc-4-mobile-features/_static/image5.png)

The display is very readable on a mobile device. Choose the ASP.NET link.

[![p1_tagged_ASPNET](aspnet-mvc-4-mobile-features/_static/image8.png)](aspnet-mvc-4-mobile-features/_static/image7.png)

The ASP.NET tag view is very cluttered. For example, the **Date** column is very difficult to read. Later in the tutorial you'll create a version of the *AllTags* view that's specifically for mobile browsers and that will make the display readable.

Note: Currently a bug exists in the mobile caching engine. For production applications, you must install the [Fixed DisplayModes](http://nuget.org/packages/Microsoft.AspNet.Mvc.FixedDisplayModes) nugget package. See [ASP.NET MVC 4 Mobile Caching Bug Fixed](https://blogs.msdn.com/b/rickandy/archive/2012/09/17/asp-net-mvc-4-mobile-caching-bug-fixed.aspx) for details on the fix.

## CSS Media Queries

[CSS media queries](http://www.w3.org/TR/css3-mediaqueries/) are an extension to CSS for media types. They allow you to create rules that override the default CSS rules for specific browsers (user agents). A common rule for CSS that targets mobile browsers is defining the maximum screen size. The *Content\Site.css* file that's created when you create a new ASP.NET MVC 4 Internet project contains the following media query:

    @media only screen and (max-width: 850px) {

If the browser window is 850 pixels wide or less, it will use the CSS rules inside this media block. You can use CSS media queries like this to provide a better display of HTML content on small browsers (like mobile browsers) than the default CSS rules that are designed for the wider displays of desktop browsers.

## The Viewport Meta Tag

Most mobile browsers define a virtual browser window width (the *viewport*) that's much larger than the actual width of the mobile device. This allows mobile browsers to fit the entire web page inside the virtual display. Users can then zoom in on interesting content. However, if you set the viewport width to the actual device width, no zooming is required, because the content fits in the mobile browser.

The viewport `<meta>` tag in the ASP.NET MVC 4 layout file sets the viewport to the device width. The following line shows the viewport `<meta>` tag in the ASP.NET MVC 4 layout file.

    <meta name="viewport" content="width=device-width">

## Examining the Effect of CSS Media Queries and the Viewport Meta Tag

Open the *Views\Shared\\_Layout.cshtml* file in the editor and comment out the viewport `<meta>` tag. The following markup shows the commented-out line.

    @*<meta name="viewport" content="width=device-width">*@

Open the *MvcMobile\Content\Site.css*file in the editor and change the maximum width in the media query to zero pixels. This will prevent the CSS rules from being used in mobile browsers. The following line shows the modified media query:

    @media only screen and (max-width: 0px) { ...

Save your changes and browse to the Conference application in a mobile browser emulator. The tiny text in the following image is the result of removing the viewport `<meta>` tag. With no viewport `<meta>` tag, the browser is zooming out to the default viewport width (850 pixels or wider for most mobile browsers.)

[![p1_noViewPort](aspnet-mvc-4-mobile-features/_static/image10.png)](aspnet-mvc-4-mobile-features/_static/image9.png)

Undo your changes — uncomment the viewport `<meta>` tag in the layout file and restore the media query to 850 pixels in the *Site.css* file. Save your changes and refresh the mobile browser to verify that the mobile-friendly display has been restored.

The viewport `<meta>` tag and the CSS media query are not specific to ASP.NET MVC 4, and you can take advantage of these features in any web application. But they are now built into the files that are generated when you create a new ASP.NET MVC 4 project.

For more information about the viewport `<meta>` tag, see [A tale of two viewports — part two](http://www.quirksmode.org/mobile/viewports2.html).

In the next section you'll see how to provide mobile-browser specific views.

## Overriding Views, Layouts, and Partial Views

A significant new feature in ASP.NET MVC 4 is a simple mechanism that lets you override any view (including layouts and partial views) for mobile browsers in general, for an individual mobile browser, or for any specific browser. To provide a mobile-specific view, you can copy a view file and add *.Mobile* to the file name. For example, to create a mobile *Index* view, copy *Views\Home\Index.cshtml* to *Views\Home\Index.Mobile.cshtml*.

In this section, you'll create a mobile-specific layout file.

To start, copy *Views\Shared\\_Layout.cshtml* to *Views\Shared\\_Layout.Mobile.cshtml*. Open *\_Layout.Mobile.cshtml* and change the title from **MVC4 Conference** to **Conference (Mobile)**.

In each `Html.ActionLink` call, remove "Browse by" in each link *ActionLink*. The following code shows the completed body section of the mobile layout file.

    <!DOCTYPE html>
    <html>
    <head>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width" />
        <title>@ViewBag.Title</title>
        @Styles.Render("~/Content/css")
        @Scripts.Render("~/bundles/modernizr")
    </head>
    <body>
        <div id="title">
            <h1> Conference (Mobile)</h1>
        </div>
        <div id="menucontainer">
            <ul id="menu">
                <li>@Html.ActionLink("Home", "Index", "Home")</li>
                <li>@Html.ActionLink("Date", "AllDates", "Home")</li>
                <li>@Html.ActionLink("Speaker", "AllSpeakers", "Home")</li>
                <li>@Html.ActionLink("Tag", "AllTags", "Home")</li>
            </ul>
        </div>
        @RenderBody()
    
        @Scripts.Render("~/bundles/jquery")
        @RenderSection("scripts", required: false)
    </body>
    </html>

Copy the *Views\Home\AllTags.cshtml* file to *Views\Home\AllTags.Mobile.cshtml*. Open the new file and change the `<h2>` element from "Tags" to "Tags (M)":

    <h2>Tags (M)</h2>

Browse to the tags page using a desktop browser and using mobile browser emulator. The mobile browser emulator shows the two changes you made.

[![p2m_layoutTags.mobile](aspnet-mvc-4-mobile-features/_static/image12.png)](aspnet-mvc-4-mobile-features/_static/image11.png)

In contrast, the desktop display has not changed.

[![p2_layoutTagsDesktop](aspnet-mvc-4-mobile-features/_static/image14.png)](aspnet-mvc-4-mobile-features/_static/image13.png)

## Browser-Specific Views

In addition to mobile-specific and desktop-specific views, you can create views for an individual browser. For example, you can create views that are specifically for the iPhone browser. In this section, you'll create a layout for the iPhone browser and an iPhone version of the *AllTags* view.

Open the *Global.asax* file and add the following code to the `Application_Start` method.

    DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("iPhone")
    {
        ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf
            ("iPhone", StringComparison.OrdinalIgnoreCase) >= 0)
    });

This code defines a new display mode named "iPhone" that will be matched against each incoming request. If the incoming request matches the condition you defined (that is, if the user agent contains the string "iPhone"), ASP.NET MVC will look for views whose name contains the "iPhone" suffix.

In the code, right-click `DefaultDisplayMode`, choose **Resolve**, and then choose `using System.Web.WebPages;`. This adds a reference to the `System.Web.WebPages` namespace, which is where the `DisplayModes` and `DefaultDisplayMode` types are defined.

[![p2_resolve](aspnet-mvc-4-mobile-features/_static/image16.png)](aspnet-mvc-4-mobile-features/_static/image15.png)

Alternatively, you can just manually add the following line to the `using` section of the file.

    using System.Web.WebPages;

The complete contents of the *Global.asax* file is shown below.

    using System;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.WebPages;
    
    namespace MvcMobile
    {
    
        public class MvcApplication : System.Web.HttpApplication
        {
            protected void Application_Start()
            {
                DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("iPhone")
                {
                    ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf
                        ("iPhone", StringComparison.OrdinalIgnoreCase) >= 0)
                });
    
                AreaRegistration.RegisterAllAreas();
    
                WebApiConfig.Register(GlobalConfiguration.Configuration);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
            }
        }
    }

Save the changes. Copy the *MvcMobile\Views\Shared\\_Layout.Mobile.cshtml* file to *MvcMobile\Views\Shared\\_Layout.iPhone.cshtml*. Open the new file and then change the `h1` heading from `Conference (Mobile)` to `Conference (iPhone)`.

Copy the *MvcMobile\Views\Home\AllTags.Mobile.cshtml* file to *MvcMobile\Views\Home\AllTags.iPhone.cshtml*. In the new file, change the `<h2>` element from "Tags (M)" to "Tags (iPhone)".

Run the application. Run a mobile browser emulator, make sure its user agent is set to "iPhone", and browse to the *AllTags* view. The following screenshot shows the *AllTags* view rendered in the [Safari](http://www.apple.com/safari/download/) browser. You can download Safari for Windows [here](https://support.apple.com/kb/DL1531).

[![p2_iphoneView](aspnet-mvc-4-mobile-features/_static/image18.png)](aspnet-mvc-4-mobile-features/_static/image17.png)

In this section we've seen how to create mobile layouts and views and how to create layouts and views for specific devices such as the iPhone. In the next section you'll see how to leverage jQuery Mobile for more compelling mobile views.

## Using jQuery Mobile

The [jQuery Mobile](http://jquerymobile.com/demos/1.0b3/#/demos/1.0b3/docs/about/intro.html) library provides a user interface framework that works on all the major mobile browsers. jQuery Mobile applies *progressive enhancement* to mobile browsers that support CSS and JavaScript. Progressive enhancement allows all browsers to display the basic content of a web page, while allowing more powerful browsers and devices to have a richer display. The JavaScript and CSS files that are included with jQuery Mobile style many elements to fit mobile browsers without making any markup changes.

In this section you'll install the *jQuery.Mobile.MVC* NuGet package, which installs jQuery Mobile and a view-switcher widget.

To start, delete the *Shared\\_Layout.Mobile.cshtml* and *Shared\\_Layout.iPhone.cshtml* files that you created earlier.

Rename *Views\Home\AllTags.Mobile.cshtml* and *Views\Home\AllTags.iPhone.cshtml* files to *Views\Home\AllTags.iPhone.cshtml.hide*and*Views\Home\AllTags.Mobile.cshtml.hide*. Because the files no longer have a *.cshtml* extension, they won't be used by the ASP.NET MVC runtime to render the *AllTags* view.

Install the *jQuery.Mobile.MVC*NuGet package by doing this:

1. From the **Tools** menu, select **Package Manager Console**, and then select **Library Package Manager**.

    [![p3_packageMgr](aspnet-mvc-4-mobile-features/_static/image20.png)](aspnet-mvc-4-mobile-features/_static/image19.png)
2. In the **Package Manager Console**, enter `Install-Package jQuery.Mobile.MVC -version 1.0.0`

The following image shows the files added and changed to the MvcMobile project by the NuGet jQuery.Mobile.MVC package. Files which are added have [add] appended after the file name. The image does not show the GIF and PNG files added to the *Content\images* folder.

![](aspnet-mvc-4-mobile-features/_static/image21.png)

The jQuery.Mobile.MVC NuGet package installs the following:

- The *App\_Start\BundleMobileConfig.cs* file, which is needed to reference the jQuery JavaScript and CSS files added. You must follow the instructions below and reference the mobile bundle defined in this file.
- jQuery Mobile CSS files.
- A `ViewSwitcher` controller widget (*Controllers\ViewSwitcherController.cs*).
- jQuery Mobile JavaScript files.
- A jQuery Mobile-styled layout file (*Views\Shared\\_Layout.Mobile.cshtml*).
- A view-switcher partial view *(MvcMobile\Views\Shared\\_ViewSwitcher.cshtml*) that provides a link at the top of each page to switch from desktop view to mobile view and vice versa.
- Several*.png* and *.gif* image files in the *Content\images* folder.

Open the *Global.asax* file and add the following code as the last line of the `Application_Start` method.

    BundleMobileConfig.RegisterBundles(BundleTable.Bundles);

The following code shows the complete *Global.asax* file.

[!code[Main](aspnet-mvc-4-mobile-features/samples/sample1.xml?highlight=26)]

> [!NOTE] If you are using Internet Explorer 9 and you don't see the `BundleMobileConfig` line above in yellow highlight, click the [Compatibility View button](https://windows.microsoft.com/en-US/windows7/How-to-use-Compatibility-View-in-Internet-Explorer-9)![Picture of the Compatibility View button (off)](http://res2.windows.microsoft.com/resbox/en/Windows 7/main/f080e77f-9b66-4ac8-9af0-803c4f8a859c_15.jpg "Picture of the Compatibility View button (off)") in IE to make the icon change from an outline ![Picture of the Compatibility View button (off)](http://res2.windows.microsoft.com/resbox/en/Windows 7/main/f080e77f-9b66-4ac8-9af0-803c4f8a859c_15.jpg "Picture of the Compatibility View button (off)") to a solid color ![Picture of the Compatibility View button (on)](http://res1.windows.microsoft.com/resbox/en/Windows 7/main/156805ff-3130-481b-a12d-4d3a96470f36_14.jpg "Picture of the Compatibility View button (on)"). Alternatively you can view this tutorial in FireFox or Chrome.


Open the *MvcMobile\Views\Shared\\_Layout.Mobile.cshtml* file and add the following markup directly after the `Html.Partial` call:

    <div data-role="header" align="center">
        @Html.ActionLink("Home", "Index", "Home")
        @Html.ActionLink("Date", "AllDates")
        @Html.ActionLink("Speaker", "AllSpeakers")
        @Html.ActionLink("Tag", "AllTags")
    </div>

The complete *MvcMobile\Views\Shared\\_Layout.Mobile.cshtml* file is shown below:

    <!DOCTYPE html>
    <html>
    <head>
        <meta charset="utf-8" />
        <title>@ViewBag.Title</title>
        <meta name="viewport" content="width=device-width" />
        @Styles.Render("~/Content/Mobile/css", "~/Content/jquerymobile/css")
        @Scripts.Render("~/bundles/jquery", "~/bundles/jquerymobile")
    </head>
    <body>
    
        <div data-role="page" data-theme="a">
            @Html.Partial("_ViewSwitcher")
            <div data-role="header" align="center">
                @Html.ActionLink("Home", "Index", "Home")
                @Html.ActionLink("Date", "AllDates")
                @Html.ActionLink("Speaker", "AllSpeakers")
                @Html.ActionLink("Tag", "AllTags")
            </div>
            <div data-role="header">
                <h1>@ViewBag.Title</h1>
            </div>
    
            <div data-role="content">
                @RenderSection("featured", false)
                @RenderBody()
            </div>
    
        </div>
    
    </body>
    </html>

Build the application, and in your mobile browser emulator browse to the *AllTags* view. You see the following:

[![p3_afterNuGet](aspnet-mvc-4-mobile-features/_static/image23.png)](aspnet-mvc-4-mobile-features/_static/image22.png)

> [!NOTE] You can debug the mobile specific code by [setting the user agent string](http://www.howtogeek.com/113439/how-to-change-your-browsers-user-agent-without-installing-any-extensions/) for IE or Chrome to iPhone and then using the F-12 developer tools. If your mobile browser doesn't display the **Home**, **Speaker**, **Tag**, and **Date** links as buttons, the references to jQuery Mobile scripts and CSS files are probably not correct.


In addition to the style changes, you see **Displaying mobile view** and a link that lets you switch from mobile view to desktop view. Choose the **Desktop view** link, and the desktop view is displayed.

[![p3_desktopView](aspnet-mvc-4-mobile-features/_static/image25.png)](aspnet-mvc-4-mobile-features/_static/image24.png)

The desktop view doesn't provide a way to directly navigate back to the mobile view. You'll fix that now. Open the *Views\Shared\\_Layout.cshtml* file. Just under the page `body` element, add the following code, which renders the view-switcher widget:

    @Html.Partial("_ViewSwitcher")

Refresh the *AllTags* view in the mobile browser. You can now navigate between desktop and mobile views.

[![p3_desktopViewWithMobileLink](aspnet-mvc-4-mobile-features/_static/image27.png)](aspnet-mvc-4-mobile-features/_static/image26.png)

> [!NOTE] Debug note: You can add the following code to the end of the Views\Shared\\_ViewSwitcher.cshtml to help debug views when using a browser the user agent string set to a mobile device.
> 
>     else
>     {
>          @:Not Mobile/Get
>     }
> 
>  and adding the following heading to the *Views\Shared\\_Layout.cshtml* file.  
> 
>     <h1> Non Mobile Layout MVC4 Conference </h1>


Browse to the *AllTags* page in a desktop browser. The view-switcher widget is not displayed in a desktop browser because it's added only to the mobile layout page. Later in the tutorial you'll see how you can add the view-switcher widget to the desktop view.

[![p3_desktopBrowser](aspnet-mvc-4-mobile-features/_static/image29.png)](aspnet-mvc-4-mobile-features/_static/image28.png)

## Improving the Speakers List

In the mobile browser, select the **Speakers** link. Because there's no mobile view(*AllSpeakers.Mobile.cshtml*), the default speakers display (*AllSpeakers.cshtml*) is rendered using the mobile layout view (*\_Layout.Mobile.cshtml*).

[![p3_speakersDeskTop](aspnet-mvc-4-mobile-features/_static/image31.png)](aspnet-mvc-4-mobile-features/_static/image30.png)

You can globally disable a default (non-mobile) view from rendering inside a mobile layout by setting `RequireConsistentDisplayMode` to `true` in the *Views\\_ViewStart.cshtml* file, like this:

    @{
        Layout = "~/Views/Shared/_Layout.cshtml";
        DisplayModeProvider.Instance.RequireConsistentDisplayMode = true;
    }

When `RequireConsistentDisplayMode` is set to `true`, the mobile layout (*\_Layout.Mobile.cshtml*) is used only for mobile views. (That is, the view file is of the form ***ViewName**.Mobile.cshtml*.) You might want to set `RequireConsistentDisplayMode` to `true` if your mobile layout doesn't work well with your non-mobile views. The screenshot below shows how the *Speakers* page renders when `RequireConsistentDisplayMode` is set to `true`.

[![p3_speakersConsistent](aspnet-mvc-4-mobile-features/_static/image33.png)](aspnet-mvc-4-mobile-features/_static/image32.png)

You can disable consistent display mode in a view by setting `RequireConsistentDisplayMode` to `false` in the view file. The following markup in the *Views\Home\AllSpeakers.cshtml* file sets `RequireConsistentDisplayMode` to `false`:

    @model IEnumerable<string>
    
    @{
        ViewBag.Title = "All speakers";
        DisplayModeProvider.Instance.RequireConsistentDisplayMode = false;
    }

## Creating a Mobile Speakers View

As you just saw, the *Speakers* view is readable, but the links are small and are difficult to tap on a mobile device. In this section, you'll create a mobile-specific *Speakers* view that looks like a modern mobile application — it displays large, easy-to-tap links and contains a search box to quickly find speakers.

Copy *AllSpeakers.cshtml* to *AllSpeakers.Mobile.cshtml*. Open the *AllSpeakers.Mobile.cshtml* file and remove the `<h2>` heading element.

In the `<ul>` tag, add the `data-role` attribute and set its value to `listview`. Like other [`data-*` attributes](http://html5doctor.com/html5-custom-data-attributes/), `data-role="listview"` makes the large list items easier to tap. This is what the completed markup looks like:

    @model IEnumerable<string>
    
    @{
        ViewBag.Title = "All speakers";
    }
    <ul data-role="listview">
        @foreach(var speaker in Model) {
            <li>@Html.ActionLink(speaker, "SessionsBySpeaker", new { speaker })</li>
        }
    </ul>

Refresh the mobile browser. The updated view looks like this:

[![p3_updatedSpeakerView1](aspnet-mvc-4-mobile-features/_static/image35.png)](aspnet-mvc-4-mobile-features/_static/image34.png)

Although the mobile view has improved, it's difficult to navigate the long list of speakers. To fix this, in the `<ul>` tag, add the `data-filter` attribute and set it to `true`. The code below shows the `ul` markup.

    <ul data-role="listview" data-filter="true">

The following image shows the search filter box at the top of the page that results from the `data-filter` attribute.

[![ps_Data_Filter](aspnet-mvc-4-mobile-features/_static/image37.png)](aspnet-mvc-4-mobile-features/_static/image36.png)

As you type each letter in the search box, jQuery Mobile filters the displayed list as shown in the image below.

[![ps_data_filter_SC](aspnet-mvc-4-mobile-features/_static/image39.png)](aspnet-mvc-4-mobile-features/_static/image38.png)

## Improving the Tags List

Like the default *Speakers* view, the*Tags* view is readable, but the links are small and difficult to tap on a mobile device. In this section, you'll fix the *Tags* view the same way you fixed the *Speakers* view.

Remove the &quot;hide&quot; suffix to the the *Views\Home\AllTags.Mobile.cshtml.hide* file so the name is *Views\Home\AllTags.Mobile.cshtml*. Open the renamed file and remove the `<h2>` element.

Add the `data-role` and `data-filter` attributes to the `<ul>` tag, as shown here:

    <ul data-role="listview" data-filter="true">

The image below shows the tags page filtering on the letter `J`.

[![p3_tags_J](aspnet-mvc-4-mobile-features/_static/image41.png)](aspnet-mvc-4-mobile-features/_static/image40.png)

## Improving the Dates List

You can improve the *Dates* view like you improved the *Speakers* and *Tags* views, so that it's easier to use on a mobile device.

Copy the *Views\Home\AllDates.cshtml* file to *Views\Home\AllDates.Mobile.cshtml*. Open the new file and remove the `<h2>` element.

Add `data-role="listview"` to the `<ul>` tag, like this:

    <ul data-role="listview">

The image below shows what the **Date** page looks like with the `data-role` attribute in place.

[![p3_dates1](aspnet-mvc-4-mobile-features/_static/image43.png)](aspnet-mvc-4-mobile-features/_static/image42.png)Replace the contents of the *Views\Home\AllDates.Mobile.cshtml* file with the following code:

    @model IEnumerable<DateTime>
    @{
        ViewBag.Title = "All dates";
        DateTime lastDay = default(DateTime);
    }
    <ul data-role="listview">
        @foreach(var date in Model) {
            if (date.Date != lastDay) {
                lastDay = date.Date;
                <li data-role="list-divider">@date.Date.ToString("ddd, MMM dd")</li>
            }
            <li>@Html.ActionLink(date.ToString("h:mm tt"), "SessionsByDate", new { date })</li>
        }
    </ul>

This code groups all sessions by days. It creates a list divider for each new day, and it lists all the sessions for each day under a divider. Here's what it looks like when this code runs:

[![p3_dates2](aspnet-mvc-4-mobile-features/_static/image45.png)](aspnet-mvc-4-mobile-features/_static/image44.png)

## Improving the SessionsTable View

In this section, you'll create a mobile-specific view of sessions. The changes we make will be more extensive than in other views we have created.

In the mobile browser, tap the **Speaker** button, then enter `Sc` in the search box.

[![ps_data_filter_SC](aspnet-mvc-4-mobile-features/_static/image47.png)](aspnet-mvc-4-mobile-features/_static/image46.png)

Tap the **Scott Hanselman** link.

[![p3_scottHa](aspnet-mvc-4-mobile-features/_static/image49.png)](aspnet-mvc-4-mobile-features/_static/image48.png)

As you can see, the display is difficult to read on a mobile browser. The date column is hard to read and the tags column is out of the view. To fix this, copy *Views\Home\SessionsTable.cshtml* to *Views\Home\SessionsTable.Mobile.cshtml*, and then replace the contents of the file with the following code:

    @using MvcMobile.Models
    @model IEnumerable<Session>
    
    <ul data-role="listview">
        @foreach(var session in Model) {
            <li>
                <a href="@Url.Action("SessionByCode", new { session.Code })">
                    <h3>@session.Title</h3>
                    <p><strong>@string.Join(", ", session.Speakers)</strong></p>
                    <p>@session.DateText</p>
                </a>
            </li>                                           
        }    
    </ul>

The code removes the room and tags columns, and formats the title, speaker, and date vertically, so that all this information is readable on a mobile browser. The image below reflects the code changes.

[![ps_SessionsByScottHa](aspnet-mvc-4-mobile-features/_static/image51.png)](aspnet-mvc-4-mobile-features/_static/image50.png)

## Improving the SessionByCode View

Finally, you'll create a mobile-specific view of the *SessionByCode* view. In the mobile browser, tap the **Speaker** button, then enter `Sc` in the search box.

[![ps_data_filter_SC](aspnet-mvc-4-mobile-features/_static/image53.png)](aspnet-mvc-4-mobile-features/_static/image52.png)

Tap the **Scott Hanselman** link. Scott Hanselman's sessions are displayed.

[![ps_SessionsByScottHa](aspnet-mvc-4-mobile-features/_static/image55.png)](aspnet-mvc-4-mobile-features/_static/image54.png)

Choose the **An Overview of the MS Web Stack of Love** link.

[![ps_love](aspnet-mvc-4-mobile-features/_static/image57.png)](aspnet-mvc-4-mobile-features/_static/image56.png)

The default desktop view is fine, but you can improve it.

Copy the *Views\Home\SessionByCode.cshtml* to *Views\Home\SessionByCode.cshtml* and replace the contents of the *Views\Home\SessionByCode.Mobile.cshtml* file with the following markup:

    @model MvcMobile.Models.Session
    
    @{
        ViewBag.Title = "Session details";
    }
    <h2>@Model.Title</h2>
    <p>
        <strong>@Model.DateText</strong> in <strong>@Model.Room</strong>
    </p>
    
    <ul data-role="listview" data-inset="true">
        <li data-role="list-divider">Speakers</li>
        @foreach (var speaker in Model.Speakers) {
            <li>@Html.ActionLink(speaker, "SessionsBySpeaker", new { speaker })</li>
        }
    </ul>
    
    <p>@Model.Description</p>
    <h4>Code: @Model.Code</h4>
    
    <ul data-role="listview" data-inset="true">
        <li data-role="list-divider">Tags</li>
        @foreach (var tag in Model.Tags) {
            <li>@Html.ActionLink(tag, "SessionsByTag", new { tag })</li>
        }
    </ul>

The new markup uses the `data-role` attribute to improve the layout of the view.

Refresh the mobile browser. The following image reflects the code changes that you just made:

[![p3_love2](aspnet-mvc-4-mobile-features/_static/image59.png)](aspnet-mvc-4-mobile-features/_static/image58.png)

## Wrapup and Review

This tutorial has introduced the new mobile features of ASP.NET MVC 4 Developer Preview. The mobile features include:

- The ability to override layout, views, and partial views, both globally and for an individual view.
- Control over layout and partial override enforcement using the `RequireConsistentDisplayMode` property.
- A view-switcher widget for mobile views than can also be displayed in desktop views.
- Support for supporting specific browsers, such as the iPhone browser.

## See Also

- [jQuery Mobile](http://jquerymobile.com) site.
- [jQuery Mobile Overview](http://jquerymobile.com/demos/1.0b3/docs/about/intro.html)
- [W3C Recommendation Mobile Web Application Best Practices](http://www.w3.org/TR/mwabp/)
- [W3C Candidate Recommendation for media queries](http://www.w3.org/TR/css3-mediaqueries/)