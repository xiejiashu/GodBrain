using System.Linq;
using Verse;

namespace GodBrain
{
    public class HeadiffComp_GodBrain : HediffComp
    {
        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            // 获取人物的身体部位列表
            var parts = this.Pawn.health.hediffSet.GetNotMissingParts();

            // 遍历每个身体部位
            foreach (var part in parts)
            {
                // 跳过大脑部位
                if (part.def.defName == "Brain") continue;

                // 获取身体部位的 hediffs
                var hediffs = this.Pawn.health.hediffSet.hediffs;

                // 在 hediffs 中查找对应的身体部位
                var hediff = hediffs.FirstOrDefault(h => h.Part == part);

                // 如果找到了 hediff，则修改它的效率
                if (hediff != null)
                {
                    // 将身体部位的效率设置为 150%
                    hediff.def.addedPartProps.partEfficiency = 99999.0f;
                }
            }
        }
    }
}