﻿function onCommand(e, record) {
    DetailsFormPanel.getForm().reset();
    DetailsFormPanel.getForm().loadRecord(record);
    DetailsFormPanel.getForm().clearInvalid();

    tfCode.rvConfig.remoteValidated = false;
    tfCode.rvConfig.remoteValid = false;

    tfName.rvConfig.remoteValidated = false;
    tfName.rvConfig.remoteValid = false;

    tfCode.markAsValid();
    tfName.markAsValid();
    DetailWindow.show();
}

function New() {

    DetailsFormPanel.getForm().reset();
    tfCode.rvConfig.remoteValidated = false;
    tfCode.rvConfig.remoteValid = false;

    tfName.rvConfig.remoteValidated = false;
    tfName.rvConfig.remoteValid = false;

    DetailWindow.show();

}

function MasterRowSelect(e, record) {
    if (pnlSouth.isVisible())
        StationLinksGrid.getStore().reload();
}

function ClearStationLinkForm() {
    StationLinkFormPanel.getForm().reset();
}

function onStationLinkCommand(e, record) {
    if (e === 'Delete') {
        DirectCall.ConfirmDeleteStationLink(record.get('Id'), { eventMask: { showMask: true } });
    } else if (e === 'Edit') {
        StationLinkFormPanel.getForm().reset();
        StationLinkFormPanel.getForm().loadRecord(record);
        StationLinkFormPanel.getForm().clearInvalid();
        StationLinkWindow.show();
    }
}

