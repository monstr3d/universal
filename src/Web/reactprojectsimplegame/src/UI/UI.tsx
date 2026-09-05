import styles from "./UI.module.scss";
import NumberOfRounds from "./NumberOfRounds/NumberOfRounds";
import QuickAccessSlots from "./QuickAccessSlots/QuickAccessSlots";
import { IAimingStore, useAimingStore } from "../store/AimingStore";

const UI = () => {
    const isAiming = useAimingStore((state: IAimingStore) => state.isAiming);

    return (
        <div className="ui-root">
            {!isAiming && <div className={styles.aim} />}
            <NumberOfRounds/>
            <QuickAccessSlots />
        </div>
    );
};

export default UI;

