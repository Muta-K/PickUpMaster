<?php
/**
 * @var \App\View\AppView $this
 * @var \App\Model\Entity\Pickupmaster $pickupmaster
 */
?>
<nav class="large-3 medium-4 columns" id="actions-sidebar">
    <ul class="side-nav">
        <li class="heading"><?= __('Actions') ?></li>
        <li><?= $this->Form->postLink(
                __('Delete'),
                ['action' => 'delete', $pickupmaster->Id],
                ['confirm' => __('Are you sure you want to delete # {0}?', $pickupmaster->Id)]
            )
        ?></li>
        <li><?= $this->Html->link(__('List Pickupmaster'), ['action' => 'index']) ?></li>
    </ul>
</nav>
<div class="pickupmaster form large-9 medium-8 columns content">
    <?= $this->Form->create($pickupmaster) ?>
    <fieldset>
        <legend><?= __('Edit Pickupmaster') ?></legend>
        <?php
        ?>
    </fieldset>
    <?= $this->Form->button(__('Submit')) ?>
    <?= $this->Form->end() ?>
</div>
