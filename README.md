EPiServer CMS UI Extension Samples
========================

This is a project that shows examples of how you can use both built in and custom functionality to adapt the user interface for Episerver. These samples are valid for both Episerver CMS and Commerce though there are no Commerce specific examples right now. The intension is that this can be used as both educational material as well as just a starting point for extending the Episerver UI.

This project currently shows the following concepts:

* Adding properties to your models
 * Using built in attributes for content selection.
 * Building customized content selection.
 * Using AllowedTypes to narrow down possible content selection for content areas.
 * Using PropertySettings to define a stripped down text editor.
 * Using SelectOne and SelectMany attributes to configure selection properties (select and checkboxes).
 * Building a selection property for values based on an Enum.
 * Configuring a list property with a custom model.
* Adding additional views for a content type.
* Configuring the icon and behaviour for a content type.

## Getting started

Download or clone this project and move it as a sub folder to an Episerver web project that is using Asp.NET MVC 5. After this, it should be possible to compile and run the solution.

### How to explore the functionality
There are a few page model classes that can be used to explore the functionality. A suggestion is to look through them in the following order:

1. SamplePageOne
2. SamplePageTwo

Most of the extensions are showing how to configure properties for models in Episerver. These should mostly have comments connected to the code. In the SamplePageTwo class there is a comment section in the end that lists a few other functionality that is implemented in the solution that is not part of the page models.

## Wishlist

Suggestion list for additional examples that could be added:

* Visitor group criteria
* Admin plug-in
* Full sample of custom content with custom view.