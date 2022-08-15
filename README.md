# CCG-Builder
 A development-focused template of a collectible card game.
 
The goal of this project is to create a basic card game template that you can:

1. Use out-of-the-box to create a card game of your own, using the game's base mechanics to create a wide array of different cards.

2. Easily expand upon with additional card types, mechanics and more, with no to minimal coding.

To achieve that, I've created a set of basic rules, mechanics and keywords (inspired by the popular CCG "Hearthstone") which are used to define complex, intricate effects and interactions.
This allows the game to support as much mechanical complexity as reasonably possible, while also allowing you to easily expand it in the future to support additional mechanics, card types and more, without needing to modify the whole architecture.

Currently WIP.

![](GitHub%20Metadata/Screenshot%201.png)

**How it works:**
I stripped apart and defined every kind of 

I have designated an "Event" for every action in the game, such as playing a card, attacking, having something die, ending your turn, etc.

Every card in the game has a list of "Triggered Effects": Effects that are listening to a specific event from a specific origin, so that whenever that event is called from that origin, the attached effect is triggered.

It is built this way to homogenize all effects within the game and make them all follow the same process, whether they are a triggered once when you play the card, or called multiple times over the card's lifetime. 

For Example, a card with an effect that is listening to the **"OnPlay"** event could set its origin to **"This"**, so the card will trigger its effect when it is played from hand. However, if the event origin is set to **"Other"**, whenever the card is on the board (as a minion, for example) and another card is played, the effect will then trigger. This logic of course applies to all other types of events.

So whenever anything occurs in the game, a message is sent to the GameManager, which processes the event, and then to the EventManager, which notifies all active listeners of this event to check if the event origin matches theirs, and if so, trigger their effect.
