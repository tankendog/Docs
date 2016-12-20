---
title: "How Do I: Create a Custom HTML Helper for an MVC Application? | Microsoft Docs"
author: rick-anderson
description: "In this video Chris Pels shows how to create a custom HtmlHelper that is not available in the standard set in an MVC application. First, a sample MVC applica..."
ms.author: riande
manager: wpickett
ms.date: 12/11/2009
ms.topic: article
ms.assetid: 
ms.technology: dotnet-mvc
ms.prod: .net-framework
msc.legacyurl: /mvc/videos/mvc-2/how-do-i/how-do-i-create-a-custom-html-helper-for-an-mvc-application
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\mvc\videos\mvc-2\how-do-i\how-do-i-create-a-custom-html-helper-for-an-mvc-application.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/26705) | [View dev content](http://docs.aspdev.net/tutorials/mvc/videos/mvc-2/how-do-i/how-do-i-create-a-custom-html-helper-for-an-mvc-application.html) | [View prod content](http://www.asp.net/mvc/videos/mvc-2/how-do-i/how-do-i-create-a-custom-html-helper-for-an-mvc-application) | Picker: 27492

How Do I: Create a Custom HTML Helper for an MVC Application?
====================
by [Chris Pels](https://twitter.com/chrispels)

In this video Chris Pels shows how to create a custom HtmlHelper that is not available in the standard set in an MVC application. First, a sample MVC application is created with a demo controller and view to test the custom HtmlHelper. Next, a module is created with a public function that is an extension method which represents the implementation of the custom HtmlHelper. The custom helper is for creating &amp;lt;img&amp;gt; tags in a page and receives several inbound parameters including the id, url, and alt text for the image tag. The logic is then added to the function for returning the completed &amp;lt;img&amp;gt; tag with the specified information. Then the custom HtmlHelper is used on the demo page to display an image. Finally, the custom HtmlHelper is expanded to include multiple constructor overrides which provide flexibility for more easily creating different &amp;lt;img&amp;gt; tags.

[&#9654; Watch video (18 minutes)](https://channel9.msdn.com/Blogs/ASP-NET-Site-Videos/how-do-i-create-a-custom-html-helper-for-an-mvc-application)

>[!div class="step-by-step"] [Previous](how-do-i-implement-view-models-to-manage-data-for-aspnet-mvc-views.md) [Next](how-do-i-work-with-model-binders-in-an-mvc-application.md)