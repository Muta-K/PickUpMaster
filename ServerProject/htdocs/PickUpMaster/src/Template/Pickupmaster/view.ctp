<?php
/**
 * @var \App\View\AppView $this
 * @var \App\Model\Entity\Pickupmaster $pickupmaster
 */
?>
<nav class="large-3 medium-4 columns" id="actions-sidebar">
    <ul class="side-nav">
        <li class="heading"><?= __('Actions') ?></li>
        <li><?= $this->Html->link(__('Edit Pickupmaster'), ['action' => 'edit', $pickupmaster->Id]) ?> </li>
        <li><?= $this->Form->postLink(__('Delete Pickupmaster'), ['action' => 'delete', $pickupmaster->Id], ['confirm' => __('Are you sure you want to delete # {0}?', $pickupmaster->Id)]) ?> </li>
        <li><?= $this->Html->link(__('List Pickupmaster'), ['action' => 'index']) ?> </li>
        <li><?= $this->Html->link(__('New Pickupmaster'), ['action' => 'add']) ?> </li>
    </ul>
</nav>
<div class="pickupmaster view large-9 medium-8 columns content">
    <h3><?= h($pickupmaster->Id) ?></h3>
    <table class="vertical-table">
        <tr>
            <th scope="row"><?= __('Id') ?></th>
            <td><?= $this->Number->format($pickupmaster->Id) ?></td>
        </tr>
    </table>
</div>
