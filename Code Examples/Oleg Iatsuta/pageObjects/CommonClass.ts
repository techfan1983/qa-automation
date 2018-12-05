import {Config} from "../common/ConfigClass";

export module Common {
    export function WaitForSpinnerToOff() {
        cy.get(".section-mask-image", Config.pageInteractionTimeoutWrapped).should("not.be.visible");
    }
    export function createJob() { 
        cy.get('#tn-create-job').click();
        cy.get("a[data-frame='right-panel']").click();
    }
}
