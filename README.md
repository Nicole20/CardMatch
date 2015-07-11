# CardMatch

This game is a memory game with a little twist. The player has to match all the cards, but there is a Mix Up card which means the remainning cards will be shuffled around.

# Unity Objects

- One Camera
- One empty object
- Sprites (ten different cards, a back card, background)

# Unity Components

- Add the Cards.cs to the empty object. Add each card to the GameObject Cards array and the back card to the back card GameObject in Cards.cs.
- Add the Flip.cs to the back card sprite.
- Make sure the Back Card layer is in front of the normal cards.
- The Camera should be at about (5, 4.5, -10)
