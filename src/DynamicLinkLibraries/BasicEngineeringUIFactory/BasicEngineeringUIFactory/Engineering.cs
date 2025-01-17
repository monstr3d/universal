using System;

using Diagram.UI;

using DataPerformer.Portable;
using DataPerformer.UI;
using ErrorHandler;

namespace BasicEngineering.UI.Factory
{
    partial class EngineeringUIFactory
    {
        void Run()
        {
            try
            {
                Action<Action> animation = StaticExtensionDataPerformerUI.AnimationAction;
                if (animation == null)
                {
                    animation = (Action action) =>
                    {
                        desktop.PerformFixed(startTime, step, stepCount,
                           StaticExtensionDataPerformerPortable.Factory.TimeProvider,
                           DataPerformer.Portable.DifferentialEquationProcessors.DifferentialEquationProcessor.Processor,
                           1, action, "Animation");
                    };
                }


                Action act = () =>
                {
                    Redraw();
                    if (worker.CancellationPending)
                    {
                        DataPerformer.Portable.StaticExtensionDataPerformerPortable.StopRun();
                    }
                    if (isPaused)
                    {
                        pauseEvent.WaitOne();
                        isPaused = false;
                    }
                };

                if (timeIndicator > 0)
                {
                    int count = 0;
                    double currentTime;
                    int tm = 0;
                    act += () =>
                    {
                        if (tm == timeIndicator)
                        {
                            currentTime = startTime + step * count;
                            timeIndication(currentTime);
                            tm = 0;
                        }
                        else
                        {
                            ++tm;
                        }
                        ++count;
                    };
                }
                /*  Action pau = Animation.Interfaces.StaticExtensionAnimationInterfaces.Pause;
                  if (pau != null)
                  {
                      act += pau;
                  }*/
                animation(act);
            }
            catch (Exception e)
            {
                e.ShowError(10);
                exglo = e;
            }
        }


    }
}
