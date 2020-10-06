<?php
/**
 * @var \App\View\AppView $this
 * @var \App\Model\Entity\Pickupmaster[]|\Cake\Collection\CollectionInterface $pickupmaster
 */
?>
<nav class="large-3 medium-4 columns" id="actions-sidebar">
    <ul class="side-nav">
        <li class="heading"><?= __('Actions') ?></li>
        <li><?= $this->Html->link(__('New Pickupmaster'), ['action' => 'add']) ?></li>
    </ul>
</nav>
<div class="pickupmaster index large-9 medium-8 columns content">
    <h3><?= __('Pickupmaster') ?></h3>
    <table cellpadding="0" cellspacing="0">
        <thead>
            <tr>
                <th scope="col"><?= $this->Paginator->sort('Id') ?></th>
                <th scope="col" class="actions"><?= __('Actions') ?></th>
            </tr>
        </thead>
        <tbody>
            <?php foreach ($pickupmaster as $pickupmaster): ?>
            <tr>
                <td><?= $this->Number->format($pickupmaster->Id) ?></td>
                <td class="actions">
                    <?= $this->Html->link(__('View'), ['action' => 'view', $pickupmaster->Id]) ?>
                    <?= $this->Html->link(__('Edit'), ['action' => 'edit', $pickupmaster->Id]) ?>
                    <?= $this->Form->postLink(__('Delete'), ['action' => 'delete', $pickupmaster->Id], ['confirm' => __('Are you sure you want to delete # {0}?', $pickupmaster->Id)]) ?>
                </td>
            </tr>
            <?php endforeach; ?>
        </tbody>
    </table>
    <div class="paginator">
        <ul class="pagination">
            <?= $this->Paginator->first('<< ' . __('first')) ?>
            <?= $this->Paginator->prev('< ' . __('previous')) ?>
            <?= $this->Paginator->numbers() ?>
            <?= $this->Paginator->next(__('next') . ' >') ?>
            <?= $this->Paginator->last(__('last') . ' >>') ?>
        </ul>
        <p><?= $this->Paginator->counter(['format' => __('Page {{page}} of {{pages}}, showing {{current}} record(s) out of {{count}} total')]) ?></p>
    </div>
</div>
