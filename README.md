# AirBench

## Tentative Plan V 1.0

### Tools
  - Visual Studio 2015
    - MVC
  - Insomnia??
  - MSSMS
  - Entity Framework
### Pages
#### Nav-Bar
  - Contains a link to a login page
  - Contains a link to a signup page
  - Hi, UserName
  - Logout when Logged in
  - My Benches (Benches user added)
  - My Reviews??? (Reviews user has posted)
#### Home Page - Home Controller / Index View (Mix of MVC and Json (For the Map))
  - No Autorization needed to view
  - Show overview of Map with all benches (using a Map API most likely // each benchmark is clickable)
  - Sidebar
    - Allow user to filter criteria (Min Seat - Should be 1 if being practical // Max Seat)
    - List benches in the area that fit criteria
      - Each bench is given their own div, displays a picture with their rating and description
      - Loads all benches from bench table
   - Add bench to map (Autorization required)
#### Sign-up Page -- Account Controller (MVC)
  - User signs up with their Username and Password
  - Save to database
  - Redirect to Log-in Page
#### Log-in Page -- Account Controller (MVC)
  - User logins with their Username and Password
  - Search criteria to database
  - Redirect to Home Page
#### Add Bench Page -- Bench Controller / Create View
  - Authorization Required
  - Click on map to add bench on that specific location
  - Add Form
    - Description
    - Number of Seats
    - Lat / Long will already be saved depending on where user clicked
    - Add image (Url Most likely)
  - Add/Cancel
  - Adds to bench table if successful 
#### Bench Details Page -- Bench Controller / Index??? /// Edit(or Details) View
  - No Authorization Required
  - Redirected when user clicks on benchmark in home page or clicks on bench in Side Bar
  - Loads specific bench from bench database
    - Keep track of Id in the view!!
  - Display image at the top
  - Display Rating, Description, # of Seats, Latitude and Logitude of bench in list format
  - Display all reviews
  - Load from review table where review BenchId matches Id of bench
    - Probably a bridge table
  - Add review button (Must be signed in)
  - #### Add Review  -- Review Controller / Create View
    - Not a seperate page, but only viewable when user is signed in and presses add review
    - User presses number of stars out of 5 to determine rating
    - Textbox for review
    - Submit / Cancel
    - Add to review table and probably review - bench bridge table



