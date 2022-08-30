#region
// 手上某属性牌的数量
board.MinionEnemy.Count(x=>x.IsLifeSteal==true && x.Template.Id==Card.Cards.CS3_031)>=1 //吸血属性
// 敌方攻击大于等于7的怪
board.MinionEnemy.Count(minion => minion.CurrentAtk >=7)==0
// 对面有0个怪在场上
board.MinionEnemy.Count == 0   
// 场上怪健康统计
board.MinionEnemy.Count(minion => minion.CurrentHealth <= 2) 
// 敌人场上有XXXX怪
board.MinionEnemy.Any(minion => minion.Template.Id == Cards.XXXXXX) 
// 敌方随从攻击力
board.MinionEnemy.OrderByDescending(x => x.CurrentAtk)
#endregion

#region
// 德：DRUID 猎：HUNTER 法：MAGE 骑：PALADIN 牧：PRIEST 贼：ROGUE 萨：SHAMAN 术：WARLOCK 战：WARRIOR 瞎：DEMONHUNTER
// 对方是骑士
board.EnemyClass == Card.CClass.PALADIN 
#endregion

#region
// 使用英雄牌 打dk
p.CastSpellsModifiers.AddOrUpdate(Card.Cards.ICC_831, new Modifier(-1000));
// 修改术法的优先级
p.CastSpellsModifiers.AddOrUpdate(Card.Cards.SW_439t, new Modifier(99)); 
// 王者祝福 Blessing of Kings ID：CORE_CS2_092，螃蟹骑士 Crabrider ID：YOP_031
p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CORE_CS2_092, new Modifier(-40, Card.Cards.YOP_031));
#endregion

#region
// 对面的英雄技能花费
board.EnemyAbility.CurrentCost == 1 
// 对面的英雄技能
board.EnemyAbility.Template.Id == Card.Cards.AT_132_PALADIN  
#endregion

#region board
// 手里有嘲讽随从
board.Hand.Exists(x => x.IsTaunt)
// 手牌数
board.Hand.Count 
// 敌方手牌数
board.EnemyCardCount
// 手上有小于等于2费的随从
board.Hand.Exists(card => card.CurrentCost<=2)
// 费用为x的随从
board.Hand.Exists(x=>x.CurrentCost>0 && x.Template.Id==Card.Cards.DMF_060)
// 手上有某张牌的数量 且能判定具体费用
board.Hand.Count(x=>x.CurrentCost==5 && x.Template.Id==Card.Cards.SCH_710)>=1
// 手里有硬币
board.Hand.Exists(x => x.Template.Id == Card.Cards.GAME_005)
// 手上某张牌的数量
board.Hand.Count(x => x.Template.Id == Card.Cards.SCH_514)
// 手上有奥秘类型的牌
board.Hand.Any(card => card.Template.IsSecret)
// 手上有武器类型的牌
board.Hand.Any(card => card.Type == Card.CType.WEAPON) 
// 手上有机械类型的牌大于3
board.Hand.Count(x => x.Race == Card.CRace.MECH) >= 3 
// 手上有奥秘类型的牌
board.Hand.Any(card => card.Template.IsSecret) 
// 在本个敌方回合死亡的随从
board.BaseMinionDiedThisTurnEnemy
// 在本个我方回合死亡的随从
board.BaseMinionDiedThisTurnFriend
// 本轮使用过的牌
board.CardsPlayedThisTurn
board.CthunAttack
board.CthunHealth
board.CthunTaunt
// 某一卡牌
board.Deck
// 某一buff被激活
board.ElemBuffEnabled
// 本回合最后使用
board.ElemPlayedLastTurn
// 暗影之握?在本回合中，你的治疗效果转而造成等量的伤害。
board.EmbraceTheShadow
// 对面的英雄技能
board.EnemyAbility
// 敌方所抽的牌
board.EnemyCardDraw
// 对方是什么职业
board.EnemyClass
// 敌方卡牌数
board.EnemyDeckCount
// 敌人的疲劳
board.EnemyFatigue
// 敌人的坟场
board.EnemyGraveyard
// 敌人的坟场本回合
board.EnemyGraveyardTurn
// 敌人的最大水晶数
board.EnemyMaxMana
// 敌方任务
board.EnemySideQuests
// 我方手上有
board.Hand
// 痊愈量这一局
board.HealAmountThisGame
// 敌方英雄的xx
board.HeroEnemy
// 我方英雄的xx
board.HeroFriend
// 本回合的英雄攻击值
board.HeroPowerCountThisTurn
// 英雄造成的伤害本局?
board.HeroPowerDamagesThisGa
// 本轮英雄造成的伤害
board.HeroPowerUsedThisTurn
// 护符数量?
board.IdolCount
// 是组合?
board.IsCombo
// 是额外的回合?
board.IsExtraTurn
// 是自己回合
board.IsOwnTurn
// 我方青玉魔像
board.JadeGolem
// 敌方青玉魔像
board.JadeGolemEnemy
// 锁定和过载?
board.LockAndLoad
// 锁定的费用?
board.LockedMana
// 最大可用水晶
board.ManaAvailable
board.ManaTemp
// 回合数
board.MaxMana
// 敌方随从xx
board.MinionEnemy
// 我方随从
board.MinionFriend
// 过载的水晶数
board.OverloadedMana
// 敌方的任务
board.QuestEnemy
// 我方的任务
board.QuestFriendly
// 我方奥秘
board.Secret
// 敌方奥秘
board.SecretEnemy
// 敌人的奥秘数量
board.SecretEnemyCount
// 法术费用使用的生命值?
board.SpellsCostHealth
// 踩踏?
board.Stampede
// 起始身材大小
board.StartHandSize
// 陷阱管理器 奥秘?
board.TrapMgr
// 回合数
board.TurnCount
// 敌方武器
board.WeaponEnemy
// 我方武器
board.WeaponFriend
#endregion

#region
// 敌方英雄的健康
board.HeroEnemy.CurrentHealth <= 15 
// 我方英雄的健康
board.HeroFriend.CurrentHealth 
// 自己的英雄技能为
board.Ability.Template.Id == Card.Cards.TRL_065h 
// 当前剩余法力水晶
board.ManaAvailable >= 6  
// 当前法力值
board.MaxMana ==2 
// 剩余卡牌数
board.FriendDeckCount <= 7
// 自己手上有什么牌
board.HasCardInHand(Card.Cards.SCH_244); 
// 某一卡牌使用优先级
p.PlayOrderModifiers.AddOrUpdate(Card.Cards.BAR_880, new Modifier(500));
// 自己场上有什么怪？
board.HasCardOnBoard(Card.Cards.NEW1_032)
// 场上有怪？怪类型是MINION？
board.Deck.Any(card => CardTemplate.LoadFromId(card).Type == Card.CType.MINION)   
//提高随从优先级
p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DMF_062, new Modifier(-20));
// 修改武器优先级
p.CastWeaponsModifiers.AddOrUpdate(Card.Cards.SW_034, new Modifier(-20));   
// 修改英雄技能
p.CastHeroPowerModifier.AddOrUpdate(LesserHeal, new Modifier(89)); 
// 自己武器的全局优先级
p.GlobalWeaponsAttackModifier = 200  
// 全局优先攻击级别
p.GlobalAggroModifier.Value = 370; 
// 修饰黑眼 Darkglare  ID：BT_307，数值越高越保守，就是不会拿去交换随从
p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.BT_307, new Modifier(150));
// 武器攻击保守性
p.WeaponsAttackModifiers.AddOrUpdate(Card.Cards.OG_058, new Modifier(-50));
// 交易
p.TradeModifiers.AddOrUpdate(Card.Cards.XXX, YYY);
//  地标
p.LocationsModifiers.AddOrUpdate(Card.Cards.REV_990, new Modifier(-99));
// 提高战斗邪犬威胁值
p.OnBoardBoardEnemyMinionsModifiers.AddOrUpdate(Card.Cards.BT_351, new Modifier(200));
#endregion

#region
// 场上的怪的数量
board.MinionFriend.Count > 1 
// 场上图腾怪数量大于等于2
board.MinionFriend.Count(card => card.Race == Card.CRace.TOTEM) >= 2    
// 场上某一个随从的数量
board.MinionFriend.Count(x => x.Template.Id == Card.Cards.SW_028t5);
// 自己有大于1个怪在场上
board.MinionFriend.Count >= 1
// 我方无嘲讽
!board.MinionFriend.Any(x => x.IsTaunt) 
#endregion

#region
// 自己坟场有
board.FriendGraveyard.Count(card => CardTemplate.LoadFromId(card).Id == Card.Cards.BT_025) 
// 坟场海盗数量
board.FriendGraveyard.Count(card => CardTemplate.LoadFromId(card).Race  == Card.CRace.PIRATE); 
// 自己坟场有
board.FriendGraveyard.Contains(Cards.Rhokdelar) 
#endregion

#region
// 自己头上无挂奥秘
board.Secret.Count == 0 
// 场上奥秘ExplosiveTrap
board.Secret.Contains(Cards.ExplosiveTrap) 
// 对手有奥秘
board.SecretEnemy 
#endregion

#region
// 手上有武器，武器寿命=1
board.WeaponFriend != null && board.WeaponFriend.CurrentDurability == 1 
// 手上有武器，而且是弑君
board.WeaponFriend != null && board.WeaponFriend.Template.Id == Cards.Kingsbane; 
// 自己手上武器名字叫
board.WeaponFriend.Template.Id == Cards.EaglehornBow 
#endregion

#region
// 牌库剩余奥秘
int LibraryResidueSecret = 9 - (board.FriendGraveyard.Count(card => CardTemplate.LoadFromId(card).IsSecret) + board.Hand.Count(card => card.Template.IsSecret) + board.Secret.Count);
//下回合斩杀，提高冰箱优先度
if (BoardHelper.HasPotentialLethalNextTurn(board)&& board.Hand.Exists(x => x.Template.Id == Card.Cards.EX1_295))
{
      p.CastSpellsModifiers.AddOrUpdate(Card.Cards.EX1_295, new Modifier(50));
}
// 血量不健康
board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor <= 13
//无法挽救场面，第二轮斩杀血线小于等于7，头上有冰箱，抢脸
if (BoardHelper.GetSurvivalMinionEnemy(board).Sum(x => x.CurrentHealth) > 18
   && BoardHelper.GetSecondTurnLethalRange(board) <= 7
   && board.Secret.Contains(Cards.IceBlock)
   && !(board.EnemyClass == Card.CClass.MAGE && board.SecretEnemy && !board.EnemyGraveyard.Exists(card => CardTemplate.LoadFromId(card).Id == Card.Cards.EX1_295)))
{
      p.GlobalAggroModifier.Value = 1000;
}
// 使用过的某牌数量
int luokala=board.MinionFriend.Count(x => x.Template.Id == Card.Cards.SW_028t5)+board.Hand.Count(x => x.Template.Id == Card.Cards.SW_028t5)+board.FriendGraveyard.Count(card => CardTemplate.LoadFromId(card).Id == Card.Cards.SW_028t5);
// 不对丛林毁灭战舰用血岩碎片刺背野猪人 毁灭战舰 The Juggernaut  SW_028t6 
p.CastMinionsModifiers.AddOrUpdate(Card.Cards.BAR_916, new Modifier(999,Card.Cards.SW_028t6));//血岩碎片刺背野猪人 Blood Shard Bristleback   BAR_916
#endregion
// 怎么识别大帝伤害
 private int GetSireDenathriusDamageCount(Card c)
{
  return GetTag(c, SmartBot.Plugins.API.Card.GAME_TAG.TAG_SCRIPT_DATA_NUM_2);
}

private int GetTag(Card c, GAME_TAG tag)
{
    if (c.tags != null && c.tags.ContainsKey(tag))
        return c.tags[tag];
    return -1;
}
// 如何判定注能
You can check the "card.Powered" attribute, if Powered == true, it means the card is activated, with the yellow borders in the game

#region 大帝伤害
        private int GetSireDenathriusDamageCount(Card c)
        {
            return GetTag(c, Card.GAME_TAG.TAG_SCRIPT_DATA_NUM_2);
        }

        private int GetTag(Card c, Card.GAME_TAG tag)
        {
            if (c.tags != null && c.tags.ContainsKey(tag))
                return c.tags[tag];
            return -1;
        }
        var SireDenathriusCard = board.Hand.FirstOrDefault(x => x.Template.Id == Card.Cards.REV_906t);

            if(SireDenathriusCard != null)
            {
                var sireDenaDamages = GetSireDenathriusDamageCount(SireDenathriusCard);
            }
#endregion