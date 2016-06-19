# shmup_versus

**How to add a new power up :**

- Create new empty GameObject

- Add PowerUpBehavior component

- Add script component that inherit from PowerUp and override following methods :
    * activateBonus(PlayerBehavior player) { }
    * deactivateBonus(PlayerBehavior player) { }
    * activateMalus(PlayerBehavior opponent) { }
    * deactivateMalus(PlayerBehavior opponent) { }

- On the new PowerUp inherited component you need to set the following properties :
    * Duration (type: float)
    * Icon (type: Sprite)
    * bonusIcon (type: Sprite)
    * malusIcon (type: Sprite)

- PowerUpBehavior component add a SpriteRenderer where you must set the Sprite property
