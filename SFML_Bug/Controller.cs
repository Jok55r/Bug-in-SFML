using SFML.Window;
using System;
using System.Collections.Generic;
using SFML;
using SFML.System;
using static SFML.Window.Keyboard;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using SFML.Graphics;
using System.Numerics;

namespace ZelenskiyGame
{
    class Controller
    {
        public Controller(Hero HeroToControll, PlayerKeys PlayerInput)
        {
            hero = HeroToControll;
            InputKeys = PlayerInput;
            MoveDirection = new Dictionary<KeyEventArgs, Direction>()
            {
                {PlayerInput.up, Direction.up },
                {PlayerInput.down, Direction.down },
                {PlayerInput.left, Direction.left },
                {PlayerInput.right, Direction.right }
            };
        }

        private PlayerKeys InputKeys;
        private Hero hero;
        private Dictionary<KeyEventArgs, Direction> MoveDirection;

        public void Controll(KeyEventArgs e)
        {
            if (hero == null)
                return;

            CheckInputForMove(e, hero);

            if (e == InputKeys.shoot)
                hero.Shoot();
        }
        private void CheckInputForMove(KeyEventArgs e, Hero hero)
        {
            if (e.Code == Keyboard.Key.W)
                hero.body.direction = Direction.up;
            if (e.Code == Keyboard.Key.S)
                hero.body.direction = Direction.down;
            if (e.Code == Keyboard.Key.A)
                hero.body.direction = Direction.left;
            if (e.Code == Keyboard.Key.D)
                hero.body.direction = Direction.right;


            hero.Move();
        }
    }
}