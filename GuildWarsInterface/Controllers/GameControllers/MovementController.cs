﻿#region

using System.Collections.Generic;
using GuildWarsInterface.Controllers.Base;
using GuildWarsInterface.Datastructures.Agents.Components;
using GuildWarsInterface.Declarations;

#endregion

namespace GuildWarsInterface.Controllers.GameControllers
{
        internal class MovementController : IController
        {
                public void Register(IControllerManager controllerManager)
                {
                        controllerManager.RegisterHandler(55, KeyboardMoveHandler);
                        controllerManager.RegisterHandler(56, MouseMoveHandler);
                        controllerManager.RegisterHandler(65, KeyboardStopMovingHandler);
                }

                private void KeyboardMoveHandler(List<object> objects)
                {
                        Game.Player.Character.Transformation.MovementType = (MovementType) (uint) objects[4];
                }

                private void MouseMoveHandler(List<object> objects)
                {
                        Game.Player.Character.Transformation.MovementType = MovementType.Forward;

                        var pos = (float[]) objects[1];
                        var plane = (short) (uint) objects[2];

                        Game.Player.Character.ShootProjectile(new Position(pos[0], pos[1], plane), 1F, 0x8F);
                }

                private void KeyboardStopMovingHandler(List<object> objects)
                {
                        Game.Player.Character.Transformation.MovementType = MovementType.Stop;
                }
        }
}