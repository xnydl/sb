// 德：DRUID 猎：HUNTER 法：MAGE 骑：PALADIN 牧：PRIEST 贼：ROGUE 萨：SHAMAN 术：WARLOCK 战：WARRIOR 瞎：DEMONHUNTER
// 手上某属性牌的数量
board.MinionEnemy.Count(x=>x.IsLifeSteal==true && x.Template.Id==Card.Cards.CS3_031)>=1 //吸血属性
// 对方是骑士
board.EnemyClass == Card.CClass.PALADIN 
// 使用英雄牌 打dk
p.CastSpellsModifiers.AddOrUpdate(Card.Cards.ICC_831, new Modifier(-1000));
// 对面的英雄技能
board.EnemyAbility.Template.Id == Card.Cards.AT_132_PALADIN 
// 手里有嘲讽随从
board.Hand.Exists(x => x.IsTaunt)
// 对面的英雄技能花费
board.EnemyAbility.CurrentCost == 1  
// 敌方英雄的健康
board.HeroEnemy.CurrentHealth <= 15 
// 我方英雄的健康
board.HeroFriend.CurrentHealth 
// 自己的英雄技能为
board.Ability.Template.Id == Card.Cards.TRL_065h 
// 场上的怪的数量
board.MinionFriend.Count > 1 
// 当前剩余法力水晶
board.ManaAvailable >= 6  
// 当前法力值
board.MaxMana ==2 
// 手牌数
board.Hand.Count 
// 剩余卡牌数
board.FriendDeckCount <= 7 
// 手上有小于等于2费的随从
board.Hand.Exists(card => card.CurrentCost<=2)
// 场上图腾怪数量大于等于2
board.MinionFriend.Count(card => card.Race == Card.CRace.TOTEM) >= 2    
// 费用为x的随从
board.Hand.Exists(x=>x.CurrentCost>0 && x.Template.Id==Card.Cards.DMF_060)
// 敌方攻击大于等于7的怪
board.MinionEnemy.Count(minion => minion.CurrentAtk >=7)==0
// 自己手上有什么牌
board.HasCardInHand(Card.Cards.SCH_244); 
// 手上有某张牌的数量 且能判定具体费用
board.Hand.Count(x=>x.CurrentCost==5 && x.Template.Id==Card.Cards.SCH_710)>=1
// 手里有硬币
board.Hand.Exists(x => x.Template.Id == Card.Cards.GAME_005)
// 手上某张牌的数量
board.Hand.Count(x => x.Template.Id == Card.Cards.SCH_514)
// 某一卡牌使用优先级
p.PlayOrderModifiers.AddOrUpdate(Card.Cards.BAR_880, new Modifier(500));
// 自己场上有什么怪？
board.HasCardOnBoard(Card.Cards.NEW1_032) 
// 场上某一个随从的数量
board.MinionFriend.Count(x => x.Template.Id == Card.Cards.SW_028t5);
// 对面有0个怪在场上
board.MinionEnemy.Count == 0   
// 自己有大于1个怪在场上
board.MinionFriend.Count >= 1
// 场上怪健康统计
board.MinionEnemy.Count(minion => minion.CurrentHealth <= 2) 
// 敌人场上有XXXX怪
board.MinionEnemy.Any(minion => minion.Template.Id == Cards.XXXXXX) 
// 自己坟场有
board.FriendGraveyard.Count(card => CardTemplate.LoadFromId(card).Id == Card.Cards.BT_025) 
// 坟场海盗数量
board.FriendGraveyard.Count(card => CardTemplate.LoadFromId(card).Race  == Card.CRace.PIRATE); 
// 自己坟场有
board.FriendGraveyard.Contains(Cards.Rhokdelar) 
// 场上有怪？怪类型是MINION？
board.Deck.Any(card => CardTemplate.LoadFromId(card).Type == Card.CType.MINION) 
// 手上有奥秘类型的牌
board.Hand.Any(card => card.Template.IsSecret)
// 手上有武器类型的牌
board.Hand.Any(card => card.Type == Card.CType.WEAPON) 
// 手上有机械类型的牌大于3
board.Hand.Count(x => x.Race == Card.CRace.MECH) >= 3 
// 自己头上无挂奥秘
board.Secret.Count == 0 
// 场上奥秘ExplosiveTrap
board.Secret.Contains(Cards.ExplosiveTrap) 
// 对手有奥秘
board.SecretEnemy 
// 手上有奥秘类型的牌
board.Hand.Any(card => card.Template.IsSecret) 
// 手上有武器，武器寿命=1
board.WeaponFriend != null && board.WeaponFriend.CurrentDurability == 1 
// 手上有武器，而且是弑君
board.WeaponFriend != null && board.WeaponFriend.Template.Id == Cards.Kingsbane; 
// 自己手上武器名字叫
board.WeaponFriend.Template.Id == Cards.EaglehornBow 
//提高随从优先级
p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DMF_062, new Modifier(-20)); 
// 修改术法的优先级
p.CastSpellsModifiers.AddOrUpdate(Card.Cards.SW_439t, new Modifier(99)); 
// 修改武器优先级
p.CastWeaponsModifiers.AddOrUpdate(Card.Cards.SW_034, new Modifier(-20))   
// 修改英雄技能
p.CastHeroPowerModifier.AddOrUpdate(LesserHeal, new Modifier(89)); 
// 自己武器的全局优先级
p.GlobalWeaponsAttackModifier = 200 
// 全局优先攻击级别
p.GlobalAggroModifier.Value = 370; 
// 降低某只怪的价值
p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.ART_BOT_Bundle_001,new Modifier(100));
// 武器攻击保守性
p.WeaponsAttackModifiers.AddOrUpdate(Card.Cards.OG_058, new Modifier(-50));
// 修饰黑眼 Darkglare  ID：BT_307，数值越高越保守，就是不会拿去交换随从
p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.BT_307, new Modifier(150)); 
// 提高战斗邪犬威胁值
p.OnBoardBoardEnemyMinionsModifiers.AddOrUpdate(Card.Cards.BT_351, new Modifier(200));
// 王者祝福 Blessing of Kings ID：CORE_CS2_092，螃蟹骑士 Crabrider ID：YOP_031
p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CORE_CS2_092, new Modifier(-40, Card.Cards.YOP_031));
// 我方无嘲讽
!board.MinionFriend.Any(x => x.IsTaunt) 
// 敌方随从攻击力
board.MinionEnemy.OrderByDescending(x => x.CurrentAtk)
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