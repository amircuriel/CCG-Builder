# CCG-Builder
 A development-focused template of a collectible card game.
 
I've created a foundation of flexible rules and mechanics (inspired by the popular CCG "Hearthstone"), to try and support as much mechanical complexity as possible, which can be used to create many different effects and interactions in the game, and can also be easily expanded upon to support additional mechanics, card types and more, without needing to modify the whole architecture.

This is intended to be a template anyone can use and expand upon to create a complex card game with minimal coding and effort.

Currently WIP.

![](GitHub%20Metadata/Screenshot%201.png)

**How it works:**
I stripped apart and defined every kind of 

I have designated an "Event" for every action in the game, such as playing a card, attacking, having something die, ending your turn, etc.

Every card in the game has a list of "Triggered Effects": Effects that are listening to a specific event from a specific origin, so that whenever that event is called from that origin, the attached effect is triggered.

It is built this way to homogenize all effects within the game and make them all follow the same process, whether they are a triggered once when you play the card, or called multiple times over the card's lifetime. 

For Example, a card with an effect that is listening to the **"OnPlay"** event could set its origin to **"This"**, so the card will trigger its effect when it is played from hand. However, if the event origin is set to **"Other"**, whenever the card is on the board (as a minion, for example) and another card is played, the effect will then trigger. This logic of course applies to all other types of events.

So whenever anything occurs in the game, a message is sent to the GameManager, which processes the event, and then to the EventManager, which notifies all active listeners of this event to check if the event origin matches theirs, and if so, trigger their effect.
