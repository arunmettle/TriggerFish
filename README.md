# TriggerFish Code Challenge
Below are the screenshots of the created news article component
# Web view
![image](https://user-images.githubusercontent.com/6778416/158190376-9dda6f95-c9b9-4853-936a-6ac97137f333.png)
# Tablet view
![image](https://user-images.githubusercontent.com/6778416/158191000-a8754e7a-6baa-455e-9bf2-7b9a8784da42.png)
# Mobile view - I have explicity styled the border of each news article card with a elegant border to distinguish between each other when stacked
![image](https://user-images.githubusercontent.com/6778416/158191151-9e4fbe40-fa9e-4903-8d56-d1500409dd07.png)


# Implementation
1. Simple MVC project where the data are gathered from one of the free Newsfeed APIs (Logic resides in NewsApiContext.cs) [Feed API](https://newsapi.org/).
2. Controller user- Home Controller /Index action
3. Bootstrap css framework and icon libs are utilised 
4. Preprocessor is utilized (Sass Compiler to compile SCSS files to CSS)
5. Script and Styling bundling is used for better minification and obfuscation

# Notes:
## Reason for using SCSS rather CSS to keep the styling cleaning and more understable, readable rather conventional CSS
  - Normally uses partials to create variables and also to change values of a comon variables if more than one theme is used in multi tentant sites where common blocks/components are used with different appearances
  - Uses both compiler and minifier to create different modular and more contextful styles for each components for modularity and reduce the file size in to more manageable chunks 
  - Above concept are applied to JS too
  - Any CSS framework used default styles are used as much as possible for btter productivity and overall confidence that it is operable for all devices with minimal disruption and any custom styles are added by adding a cascaded style properties to override by applying custom classes rather override existing clasees by using "!important"
  - In terms of accessibilty enough metatags/meta information are added to the elements if available and applicable. 
    
