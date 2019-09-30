# AirBench

## Tentative Plan V 1.0

### Pages
#### Nav-Bar
  - Login/Signup
  - Hi, UserName
  - Logout when Logged in
  - My Benches (Benches user added)
  - My Reviews??? (Reviews user has posted)
#### Home Page
  - No Autorization needed to view
  - Contains a link to a login page
  - Contains a link to a signup page
  - Show overview of Map with all benches (using a Map API most likely // each benchmark is clickable)
  - Sidebar
    - Allow user to filter criteria (Min Seat - Should be 1 if being practical // Max Seat)
    - List benches in the area that fit criteria
      - Each bench is given their own div, displays a picture with their rating and description
   - Add bench to map (Autorization required)
#### Sign-up Page
  - User signs up with their Username and Password
  - Save to database
  - Redirect to Log-in Page
#### Log-in Page
  - User logins with their Username and Password
  - Search criteria to database
  - Redirect to Home Page
#### Add Bench Page
  - Authorization Required
  - Click on map to add bench on that specific location
  - Add Form
    - Description
    - Number of Seats
    - Lat / Long will already be saved depending on where user clicked
    - Add image
  - Add/ Cancel
#### Bench Details Page
  - No Authorization Required
  - Redirected when user clicks on benchmark in home page or clicks on bench in Side Bar
  - Display image at the top
  - Display Rating, Description, # of Seats, Latitude and Logitude of bench in list format
  - Display all reviews
  - Add review button (Must be signed in)
  - * Add Review * 
    - Not a seperate page, but only viewable when user is signed in and presses add review
    - User presses number of stars out of 5 to determine rating
    - Textbox for review
    - Submit / Cancel


      
    

