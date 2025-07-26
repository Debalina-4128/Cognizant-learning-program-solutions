import React from 'react';
import styles from './CohortDetails.module.css';

const CohortDetails = ({ cohort }) => {
  const titleClass =
    cohort.status.toLowerCase() === 'ongoing'
      ? styles.green
      : styles.blue;

  return (
    <div className={styles.box}>
      <h3 className={`${styles.title} ${titleClass}`}>
        {cohort.name}
      </h3>
      <dl>
        <dt>Started On</dt>
        <dd>{cohort.startDate}</dd>

        <dt>Current Status</dt>
        <dd>{cohort.status}</dd>

        <dt>Coach</dt>
        <dd>{cohort.coach}</dd>

        <dt>Trainer</dt>
        <dd>{cohort.trainer}</dd>
      </dl>
    </div>
  );
};

export default CohortDetails;
